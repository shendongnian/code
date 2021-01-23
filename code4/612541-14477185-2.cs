    private static byte SaturateCast(double value)
    {
        var rounded = Math.Round(value, 0);
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
