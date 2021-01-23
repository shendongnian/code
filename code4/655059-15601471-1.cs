    private static void Main(string[] args)
    {
        var random = new Random();
        var numbers = Enumerable.Range(0, 7)
                                .Select(x => random.Next(0, 9));
        var output = string.Join(string.Empty, numbers);
        Console.WriteLine(output);
    }
