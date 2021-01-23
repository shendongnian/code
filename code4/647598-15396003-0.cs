    public static double MinIsNumber(double[,] array)
    {
        return array.Cast<double>()
            .Where(n => !double.IsNaN(n))
            .Min();
    }
