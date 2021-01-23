    Point p1 = new Point(2.0, 3.0);
    Point p2 = new Point(9.0, 9.0);
    double l = 25.0;
    Point vector = new Point(p2.X - p1.X, p2.Y - p1.Y);
    double c = Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
    double a = l / c;
    Point p3 = new Point(p1.X + vector.X * a, p1.Y + vector.Y * a);
    //Writes "25"
    Console.WriteLine(Math.Sqrt((p3.X - p1.X) * (p3.X - p1.X) + (p3.Y - p1.Y) * (p3.Y - p1.Y))); 
