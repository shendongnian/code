    public static class DoubleEx
    {
        public static double TruncateFraction(this double value, int fractionRound)
        {
            double factor = Math.Pow(10, fractionRound);
            return Math.Truncate(value * factor) / factor;
        }
    }
