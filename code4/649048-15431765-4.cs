    private static void PrintTree(List<CityInfo> source, int level)
    {
        if (source != null)
        {
            source.ForEach(c =>
            {
                Enumerable.Range(1, level).ToList().ForEach(i => Console.Write("\t"));
                Console.WriteLine(c.Name);
                PrintTree(c.Children, level + 1);
            });
        }
    }
