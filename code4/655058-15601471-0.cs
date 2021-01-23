    private static void Main(string[] args)
    {
        var rnd = new Random();
        var output = Enumerable.Range(0, 7)
                               .Aggregate(string.Empty, 
                                   (str, i) => str += rnd.Next(0, 9));
        Console.WriteLine(output);
    }
