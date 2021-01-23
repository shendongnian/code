    public static byte SaturateCast(double value)
    {
        var rounded = Math.Round(value);
        if (rounded < byte.MinValue)
        {
            rounded = byte.MinValue;
        }
        else if (rounded > byte.MaxValue)
        {
            rounded = byte.MaxValue;
        }
        return (byte)rounded;
    }
