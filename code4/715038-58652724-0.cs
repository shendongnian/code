        static void Main()
        {
            Point p;
            p.x = 1;
            p.y = 1;
            Object o = p;
            Unsafe.Unbox<Point>(o).x = 6; // error
            p = (Point)o;  // 6
            Console.WriteLine(p.x);
        }
