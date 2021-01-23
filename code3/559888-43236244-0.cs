    // Sample Usage
    int years, months;
    double test1 = 2.11;
    test1.Split(out years, out months);
    // years = 2 and months = 11
    public static class DoubleExtensions
    {
        public static void Split(this double number, out int years, out int months)
        {
            years = Convert.ToInt32(Math.Truncate(number));
            double tempMonths = Math.Round(number - years, 2);
            while ((tempMonths - Math.Floor(tempMonths)) > 0 && tempMonths != 0) tempMonths *= 10;
            months = Convert.ToInt32(tempMonths);
        }
    }
