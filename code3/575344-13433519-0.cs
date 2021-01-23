    public Constructor(int minValue,  int maxValue)
    {  
        this.Min = minValue;
        this.Max = maxValue;
    }
    public static Constructor FromMinimumValue(int minValue)
    {
        // Adjust default max value as you wish
        return new Constructor(minValue, int.MaxValue);
    }
    public static Constructor FromMaximumValue(int maxValue)
    {
        // Adjust default min value as you wish
        return new Constructor(int.MinValue, maxValue);
    }
