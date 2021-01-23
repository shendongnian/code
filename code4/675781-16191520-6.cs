    class Program
    {
    	public const long Iterations = (long)1e8;
    
    	static void Main()
    	{
    		var results = new Dictionary<string, Tuple<TimeSpan, TimeSpan>>();
    		results.Add("new List<int>()", Benchmark(new List<int>(), Iterations));
    		results.Add("Enumerable.Empty<int>()", Benchmark(Enumerable.Empty<int>(), Iterations));
            results.Add("new int[0]", Benchmark(new int[0], Iterations));
    		results.Add("MyEmpty<int>()", Benchmark(MyEmpty<int>(), Iterations));
    
    		Console.WriteLine("Function".PadRight(30) + "Any()".PadRight(10) + "Count()");
    		foreach (var result in results)
    		{
    			Console.WriteLine("{0}{1}{2}", result.Key.PadRight(30), Math.Round(result.Value.Item1.TotalSeconds, 3).ToString().PadRight(10), Math.Round(result.Value.Item2.TotalSeconds, 3));
    		}
    		Console.ReadLine();
    	}
    
    	public static Tuple<TimeSpan, TimeSpan> Benchmark(IEnumerable<int> source, long iterations)
    	{
    		var anyWatch = new Stopwatch();
    		anyWatch.Start();
    		for (long i = 0; i < iterations; i++) source.Any();
    		anyWatch.Stop();
    
    		var countWatch = new Stopwatch();
    		countWatch.Start();
    		for (long i = 0; i < iterations; i++) source.Count();
    		countWatch.Stop();
    
    		return new Tuple<TimeSpan, TimeSpan>(anyWatch.Elapsed, countWatch.Elapsed);
    	}
    
    	public static IEnumerable<T> MyEmpty<T>() { yield break; }
    }
