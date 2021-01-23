    public static decimal RoundToSignificantFigures(decimal num, int n)
    {
        if (num == 0)
        {
            return 0;
        }
        // We are only looking for the next power of 10... 
        // The double conversion could impact in some corner cases,
        // but I'm not able to construct them...
        int d = (int)Math.Ceiling(Math.Log10((double)Math.Abs(num)));
        int power = n - d;
        // Same here, Math.Pow(10, *) is an integer number
        decimal magnitude = (decimal)Math.Pow(10, power);
        // I'm using the MidpointRounding.AwayFromZero . I'm not sure
        // having a MidpointRounding.ToEven would be useful (is Banker's
        // rounding used for significant figures?)
        decimal shifted = Math.Round(num * magnitude, 0, MidpointRounding.AwayFromZero);
        decimal ret = shifted / magnitude;
        return num >= 0 ? ret : -ret;
    }
