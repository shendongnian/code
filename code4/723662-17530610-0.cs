    public static double GetAngleDegree(Point origin, Point target) {
        var n = 270 - (Math.Atan2(origin.Y - target.Y, origin.X - target.X)) * 180 / Math.PI;
        return n % 360;
    }
    static void Main(string[] args)
    {
        Console.WriteLine(GetAngleDegree(new Point(0, 0), new Point(0, 3)));//0
        Console.WriteLine(GetAngleDegree(new Point(0, 0), new Point(3, 0)));//90
        Console.WriteLine(GetAngleDegree(new Point(0, 0), new Point(0, -3)));//180
        Console.WriteLine(GetAngleDegree(new Point(0, 0), new Point(-3, 0)));//270 
    }
