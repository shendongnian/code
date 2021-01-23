    static double Truncate(double value, int digits)
    {
        double mult = System.Math.Pow(10.0, digits);
        return System.Math.Truncate(value * mult) / mult;
    }
