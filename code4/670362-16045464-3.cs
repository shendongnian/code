    public static decimal CalculateStandardDeviation(IEnumerable<decimal> values)
    {
        //...
    }
    public static double CalculateStandardDeviation(IEnumerable<double> values)
    {
        return (double)CalculateStandardDeviation(values.Select(Convert.ToDecimal));
    }
    public static int CalculateStandardDeviation(IEnumerable<int> values)
    {
        return (int)CalculateStandardDeviation(values.Select(Convert.ToDecimal));
    }
    // etc...
