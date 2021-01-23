    public static bool AboutEqual(double x, double y)
    {
        if (double.IsNaN(x)) return double.IsNaN(y); 
        if (double.IsInfinity(x)) return double.IsInfinity(y) && Math.Sign(x) == Math.Sign(y);
        double epsilon = Math.Max(Math.Abs(x), Math.Abs(y)) * 1E-15;
        return Math.Abs(x - y) <= epsilon;
    }
