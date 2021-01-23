        string[] lines = 
    	{
    		"#0",
     		"DIRECTION: FORWARD",
     		"SPEED: 10",
     		"TIME: 10"
    	};
    	
          // meaning At start of line there is a # followed by digits till the end of line
    	if(checkLine(@"^#\d+$", lines[0]) == false)
    	    Console.WriteLine("False on line 1");
    	else
    		Console.WriteLine("True on line 1");
    		
          // meaning At start of line there is the word DIRECTION: followed by space and the words REVERSE or FORWARD
    	if(checkLine(@"^DIRECTION: (REVERSE|FORWARD)", lines[1]) == false)
    	    Console.WriteLine("False on line 2");
    	else
    		Console.WriteLine("True on line 2");
    
          // meaning At start of line there is the word SPEED: followed by a space and digits till the end of the line
    	if(checkLine(@"^SPEED: \d+$", lines[2]) == false)
    	    Console.WriteLine("False on line 3");
    	else
    		Console.WriteLine("True on line 3");
    
          // meaning At start of line there are the words TIME or ROTATIONS followed by colon, space and digits till the end of the line
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
