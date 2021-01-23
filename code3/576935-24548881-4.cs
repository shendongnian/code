    private const int SIGN_MASK = ~Int32.MinValue;
    
    public static int GetDigits4(decimal value)
    {
        return (Decimal.GetBits(value)[3] & SIGN_MASK) >> 16;
    }
