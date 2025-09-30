using System;

namespace Geometry
{
    // Клас для точки
    class Tochka
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Tochka(double x = 0, double y = 0)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }

    // Базовий клас "Трикутник"
    class Trykutnyk
    {
        protected Tochka[] Vershyny = new Tochka[3];

        // Метод для введення координат вершин
        public virtual void VvestyKoordynaty()
        {
            Console.WriteLine("Введення координат трикутника:");
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"Вершина {i + 1} - X: ");
                double x = double.Parse(Console.ReadLine());
                Console.Write($"Вершина {i + 1} - Y: ");
                double y = double.Parse(Console.ReadLine());
                Vershyny[i] = new Tochka(x, y);
            }
        }

        // Метод для виведення координат
        public virtual void VyvestyKoordynaty()
        {
            Console.WriteLine("Координати вершин трикутника:");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Вершина {i + 1}: {Vershyny[i]}");
            }
        }

        // Метод для обчислення площі трикутника
        public virtual double Ploshcha()
        {
            double x1 = Vershyny[0].X, y1 = Vershyny[0].Y;
            double x2 = Vershyny[1].X, y2 = Vershyny[1].Y;
            double x3 = Vershyny[2].X, y3 = Vershyny[2].Y;

            return Math.Abs((x1*(y2 - y3) + x2*(y3 - y1) + x3*(y1 - y2)) / 2.0);
        }
    }

    // Похідний клас "Опуклий чотирикутник"
    class OpuklyiChotyrykutnyk : Trykutnyk
    {
        public OpuklyiChotyrykutnyk()
        {
            Vershyny = new Tochka[4]; // Перевизначаємо кількість вершин
        }

        public override void VvestyKoordynaty()
        {
            Console.WriteLine("Введення координат опуклого чотирикутника:");
            for (int i = 0; i < 4; i++)
            {
                Console.Write($"Вершина {i + 1} - X: ");
                double x = double.Parse(Console.ReadLine());
                Console.Write($"Вершина {i + 1} - Y: ");
                double y = double.Parse(Console.ReadLine());
                Vershyny[i] = new Tochka(x, y);
            }
        }

        public override void VyvestyKoordynaty()
        {
            Console.WriteLine("Координати вершин чотирикутника:");
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"Вершина {i + 1}: {Vershyny[i]}");
            }
        }

        public override double Ploshcha()
        {
            // Обчислюємо площу як суму площ двох трикутників
            double S1 = Math.Abs(
                (Vershyny[0].X * (Vershyny[1].Y - Vershyny[2].Y) +
                 Vershyny[1].X * (Vershyny[2].Y - Vershyny[0].Y) +
                 Vershyny[2].X * (Vershyny[0].Y - Vershyny[1].Y)) / 2.0);

            double S2 = Math.Abs(
                (Vershyny[0].X * (Vershyny[2].Y - Vershyny[3].Y) +
                 Vershyny[2].X * (Vershyny[3].Y - Vershyny[0].Y) +
                 Vershyny[3].X * (Vershyny[0].Y - Vershyny[2].Y)) / 2.0);

            return S1 + S2;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Об'єкт трикутник
            Trykutnyk trykutnyk = new Trykutnyk();
            trykutnyk.VvestyKoordynaty();
            trykutnyk.VyvestyKoordynaty();
            Console.WriteLine($"Площа трикутника: {trykutnyk.Ploshcha():F2}");

            Console.WriteLine();

            // Об'єкт опуклий чотирикутник
            OpuklyiChotyrykutnyk chotyrykutnyk = new OpuklyiChotyrykutnyk();
            chotyrykutnyk.VvestyKoordynaty();
            chotyrykutnyk.VyvestyKoordynaty();
            Console.WriteLine($"Площа опуклого чотирикутника: {chotyrykutnyk.Ploshcha():F2}");
        }
    }
}
