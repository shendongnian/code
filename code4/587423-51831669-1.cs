    public static int GetNthDigit(this int value, int digits)
    {
        double mult = Math.Pow(10.0, digits);
        if (value >= mult)
        {
            while(value >= mult)
                value /= 10;
            return value % 10;
        }
        else
        {
            throw new ArgumentOutOfRangeException("Digits greater than value");
        }
    }
