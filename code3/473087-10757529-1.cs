        string[] lines = 
    	{
    		"#0",
     		"DIRECTION: FORWARD",
     		"SPEED: 10",
     		"TIME: 10"
    	};
    	
          // meaning At start of line there is a # followed by digit
    	if(checkLine(@"^#\d+$", lines[0]) == false)
    	    Console.WriteLine("False on line 1");
    	else
    		Console.WriteLine("True on line 1");
    		
    	if(checkLine(@"^DIRECTION: (REVERSE|FORWARD)", lines[1]) == false)
    	    Console.WriteLine("False on line 2");
    	else
    		Console.WriteLine("True on line 2");
    
    	if(checkLine(@"^SPEED: \d+$", lines[2]) == false)
    	    Console.WriteLine("False on line 3");
    	else
    		Console.WriteLine("True on line 3");
    
    	if(checkLine(@"^(TIME|ROTATIONS): \d+$", lines[3]) == false)
    	    Console.WriteLine("False on line 4");
    	else
    		Console.WriteLine("True on line 4");
    }
    
    // Define other methods and classes here
    private bool checkLine(string regExp, string line)
    {
    	Regex r = new Regex(regExp);
    	return r.IsMatch(line);
    }
