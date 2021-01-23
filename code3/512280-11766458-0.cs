    public void DoFizzBuzz()
    {
        // expect this to come in as parameter
        var combinations = new Tuple<int, string>[] 
        { 
            new Tuple<int, string> (3, "Fizz"), 
            new Tuple<int, string> (5, "Buzz"), 
        };
        Func<int, int, bool> isMatch = (i, comb) => i % comb == 0;
        // expect the borders 1, 100 to come in as parameters
        for (int i = 1; i <= 100; i++)
        {
            var matchingCombs = combinations.Where(c => isMatch(i, c.Item1)).DefaultIfEmpty(new Tuple<int, string>(i, i.ToString())).Aggregate((v, w) => new Tuple<int, string>(v.Item1, v.Item2 + w.Item2)).Item2;
            Console.WriteLine(matchingCombs);
        }
    }
