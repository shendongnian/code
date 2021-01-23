    public static void Main(string[] args)
    {
        var xs = Enumerable.Range(1, 20);
        Print(xs.Batch(5).Skip(1)); // should skip first batch with 5 elements
    }
    
    public static void Print<T>(IEnumerable<IEnumerable<T>> batches)
    {
        foreach (var batch in batches)
        {
            Console.WriteLine($"[{string.Join(", ", batch)}]");
        }
    }
