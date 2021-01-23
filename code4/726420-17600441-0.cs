    var words = ReadFile("hamlet.txt");
    
    //...
    
    private static string[] ReadFile(string path)
    {
    	List<string> lines = new List<string>();
    	using (StreamReader sr = new StreamReader(path))
    	{
    		string text = sr.ReadToEnd();
    		lines.Add(text);
    	}
    
    	return lines.SelectMany(l => l.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(w => w.Trim()))
    		.Where(w => !(w.ToCharArray().All(c => c == ' ')))
    		.ToArray();
    }
