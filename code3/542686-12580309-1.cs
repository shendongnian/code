    private static readonly double MaxDecimalAsDouble = (double) decimal.MaxValue;
    private static readonly double MinDecimalAsDouble = (double) decimal.MinValue;
    ...
    public decimal ConvertWithCap(double input)
    {
        return input >= MaxDecimalAsDouble ? decimal.MaxValue
             : input <= MinDecimalAsDouble ? decimal.MinValue
             : (decimal) input;
    }
