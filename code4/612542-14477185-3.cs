    private static byte SaturateCast(double value)
    {
        var rounded = Math.Round(value, 0);
        if (rounded < byte.MinValue)
        {
            return byte.MinValue;
        }
        
        if (rounded > byte.MaxValue)
        {
            return byte.MaxValue;
        }
        return (byte)rounded;
    }
