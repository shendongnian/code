    static void Main(string[] args)
    {
        decimal[] individuals = { 10, 10, 10 };
        decimal total = individuals.Sum();
        decimal[] percentages = individuals.Select(i => i * 100 / total).ToArray();
        decimal percentageTotal = percentages.Sum();
        Console.WriteLine(string.Format("{0:N2}", percentageTotal));
        Console.ReadLine();
    }
