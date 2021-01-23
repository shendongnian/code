    static void Main(string[] args)
    {
        var history = db.History.Where(item => item.ProjId == 1)
                                .OrderBy(item => item.Date)
                                .ToArray();
        for(int i=1; i<history.Length; i++)
        {
            var diff = GetChangesBetweenRows(history[i-1], history[i]);
            DisplayDifferences(diff);
        }
    }
    static void DisplayDifferences(IEnumerable<Tuple<string, object, object>> diff)
    {
        foreach(var tuple in diff)
        {
            Console.WriteLine("Property: {0}. Object1: {1}, Object2: {2}",tuple.Item1, tuple.Item2, tuple.Item3);
        }
    }
