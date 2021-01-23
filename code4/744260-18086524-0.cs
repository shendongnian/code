    static void Main(string[] args)
    {
    	Program p = new Program();
    	String line = String.Empty;
    	using (StreamReader sr = new StreamReader("input.txt"))
    	{
    		while (!sr.EndOfStream)
    		{
    			line += sr.ReadLine();
    		}
    	}
    	String[] splitWords = p.chop(line);
    
    	for (int i = 1; i <= splitWords.Length; i++)
    	{
    		Console.WriteLine(splitWords[splitWords.Length - i]);
    	}
    	Console.ReadLine();
    }
