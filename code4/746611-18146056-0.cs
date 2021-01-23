    public static decimal RoundToSignificantFigures(decimal num, int n)
    {
        if (num == 0)
        {
            return 0;
        }
        // We are only looking for the next power of 10... 
        // The double conversion shouldn't impact, because the 
        // double range is bigger than the decimal range
        int d = (int)Math.Ceiling(Math.Log10((double)Math.Abs(num)));
        int power = n - d;
        // Same here, Math.Pow(10, *) is an integer number
        decimal magnitude = (decimal)Math.Pow(10, power);
        // I'm using the MidpointRounding.AwayFromZero . I'm not sure
        // having a MidpointRounding.ToEven would be useful (is Banker's
        // rounding used for significant figures?)
        // As the original method, the conversion to long makes the 
        // maximum number of significant digits 18
        long shifted = (long)Math.Round(num * magnitude, MidpointRounding.AwayFromZero);
        return shifted / magnitude;
    }
