    static void Main(string[] args)
    {
    	GetFizzBuzz().Take(100).ToList().ForEach(Console.WriteLine);
    }
    
    private static IEnumerable<string> GetFizzBuzz()
    {
    	for (var i = 0; i < int.MaxValue; i++)
    	{
    		if (i % 3 == 0 && i % 5 == 0) yield return "FizzBuzz";
    		if (i % 3 == 0) yield return "Fizz";
    		yield return i % 5 == 0 ? "Buzz" : i.ToString(CultureInfo.InvariantCulture);
    	}
    }
