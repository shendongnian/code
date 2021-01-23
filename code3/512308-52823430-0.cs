    public static void DoFizzBuzz()
    {
        var combinations = new (int multiple, string output)[]
        {
            (3, "Fizz"),
            (5, "Buzz")
        };
        for (int i = 1; i <= 100; ++i)
        {
            // Seed the accumulation function with an empty string and add any 'matches' from each combination
            var fb = combinations.Aggregate("", (c, comb) => c + (i % comb.multiple == 0 ? comb.output : ""));
            Console.WriteLine(!string.IsNullOrEmpty(fb) ? fb : $"{i}");
        }
    }
