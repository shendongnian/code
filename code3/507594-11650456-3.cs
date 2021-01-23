    static int BytesForNum(long value, bool signed)
    {
        if (value == 0)
            return 1;
        if (signed)
        {
            if (value < 0)
                return CalcBytes(2 * (-1-value));
            else
                return CalcBytes(2 * value);
        }
        else
        {
            if (value < 0)
                throw new ArgumentException("Can't represent a negative unsigned number", "value");
            return CalcBytes(value);
        }
    }
    //should only be called with positive numbers
    private static int CalcBytes(long value)
    {
        int bitLength = 0;
        while (value > 0)
        {
            bitLength++;
            value >>= 1;
        }
        return (int)(Math.Ceiling(bitLength * 1.0 / 8));
    }
