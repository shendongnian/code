    void Main()
    {
    	string pascalCasedString = "JustLikeYouAndMe";
    	var words = WordsFromPascalCasedString(pascalCasedString);
    	words.Dump();
    }
    
    IEnumerable<string> WordsFromPascalCasedString(string pascalCasedString)
    {
    	var rx = new Regex("([A-Z])");
    	return rx.Split(pascalCasedString)
    	         .Where(c => !string.IsNullOrEmpty(c))
    			 .InPieces(2)
    			 .Select(c => c.ElementAt(0) + c.ElementAt(1));
    }
    
    static class Ext
    {
    	public static IEnumerable<IEnumerable<T>> InPieces<T>(this IEnumerable<T> seq, int len)
    	{
    		if(!seq.Any()) 
    			yield break;
    			
    		yield return seq.Take(len);
    		
    		foreach (var element in InPieces(seq.Skip(len), len))
    			yield return element;
    	}
    }
