    static void Main(string[] args)
    {
        decimal[] individuals = { 10, 10, 10 };
        Console.WriteLine("Unrounded figures");
        var percentages = individuals.Select(i => i * 100 / individuals.Sum()).ToList();
        percentages.ForEach(p => Console.WriteLine(p.ToString()));
        decimal percentageTotal = percentages.Sum();
        Console.WriteLine("Their unrounded sum = {0}", percentageTotal);
        Console.WriteLine("Their rounded sum = {0:N2}", percentageTotal);
        Console.WriteLine();
        Console.WriteLine("Rounded figures");
        var roundedPercentages = individuals.Select(i => Math.Round(i * 100 / individuals.Sum(), 2)).ToList();
        roundedPercentages.ForEach(p => Console.WriteLine(p.ToString()));
        decimal roundedPercentageTotal = roundedPercentages.Sum();
        Console.WriteLine("Their unrounded sum = {0}", roundedPercentageTotal);
        Console.WriteLine("Their rounded sum = {0:N2}", roundedPercentageTotal);
        Console.ReadLine();
    }
