    var lines = File.ReadAllLines(@"c:\temp\samples.txt");
    
    var matched = false;
    foreach (var line in lines)
    {
    	if(matched)
    	{
    		var match = Regex.Match(line, @"public");
    		if(match.Length > 0)
    		{
    			matched = false;
    			match = Regex.Match(line, @"[a-zA-Z_]+( )?(?=\()");	
    			Console.WriteLine (match.Value);
    		}
    	}
    	else
    	{
    		matched = Regex.IsMatch(line, @"\[.*Test.*\]");
    	}
    }
