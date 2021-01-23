    static void Main(string[] args)
    {
        string decimalFormat = "0.00";
        decimal[] individuals = { 10, 10, 10 };
        decimal total = 30;
        List<decimal> percents = new List<decimal>();
        foreach (decimal t in individuals)
        {
            decimal percent = (t * 100) / total;
            percents.Add(percent);
        }
        decimal percentTotal = decimal.Zero;
        foreach (decimal percent in percents)
        {
            percentTotal += percent;
        }
        Console.WriteLine(string.Format("{0:N2}", percentTotal)); 
        Console.ReadLine();
    }
