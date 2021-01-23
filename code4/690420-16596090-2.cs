    private static IEnumerable<int> GetParts(int number)
    {
    	int remainder = number;
    	int maxPow = (int)Math.Log(number, 10);
    	for (int factor = (int)Math.Pow(10, maxPow); factor >= 1; factor /= 10)
    	{
    		int part = factor * (remainder / factor);
    		remainder -= part;
    		yield return part;
    	}
    }
    Which can be used the following way:
    List<int> parts = GetParts(1234).ToList();
    // parts[1] --> 200
