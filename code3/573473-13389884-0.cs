    static IEnumerable<Func<int>> GetEnumerable(int? page = null, int limit = 10)
    {
        var currentPage = page ?? 1;
        while (true)
        {
            var thisPage = currentPage;
            List<int> thisPageResult = null;
            // Function that evaluates this batch and returns the result
            Func<List<int>> getPageResult = () =>
            {
                // only evaluate this batch once
                if (thisPageResult == null)
                {
                    // slow retrieval of a bunch of results happens here
                    Thread.Sleep(1000);
                    // store the result for future calls
                    thisPageResult = Enumerable.Range(limit * (thisPage - 1), limit).ToList();
                }
                return thisPageResult;
            };
            for (int i = 0; i < limit; i++)
            {
                var j = i;
                // lazy: evaluate the batch only if requested by client code
                yield return () => getPageResult()[j];
            }
            currentPage++;
        }
    }
    static void Main(string[] args)
    {
        foreach (var func in GetEnumerable().Skip(100).Take(10))
        {
            Console.WriteLine(func());
        }
    }
