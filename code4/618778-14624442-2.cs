        List<Point> PlaatssnoepList = new List<Point>(); 
        for (int i = 0; i < aantal; i++)
        {
            Point p = new Point(Rangen.Next(25, 94), Rangen.Next(3, 23));
            Console.SetCursorPosition(p.X, p.Y);
            Console.WriteLine("0");
            PlaatssnoepList.Add(p)
        }
