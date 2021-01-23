    void Main()
    {
        // can be any IEnumerable<string> including string[]
    	var words = new List<string>{"one", "two", "four", "three", "four", "a", "z"};
    	
    	words.ToDistinctList().Dump();
        // you would use txtOutput.Text = words.ToDistinctList()
    }
    
    static class StringHelpers
    {
    	public static string ToDistinctList(this IEnumerable<string> words)
    	{
    		return string.Join("\n", new SortedSet<string>(words));
    	}
    }
