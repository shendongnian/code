    public static IEnumerable<short> getDigits(long input)
    {
        while (input > 0)
        {
            yield return (short)(input % 10);
            input /= 10;
        }
    }
