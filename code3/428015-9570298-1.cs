    public class PairDictionary : Dictionary<int, string>
    {
    }
    
    private static void Main(string[] args)
    {
    	var temp = new PairDictionary
    	{
    		{0, "bob"},
    		{1, "phil"},
    		{2, "nick"}
    	};
    
    	Console.ReadKey();
    }
