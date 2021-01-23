    void Main()
    {	
    	Console.WriteLine (TrimLastPart("http://stackoverflow.com/questions/ask/randomcrap.html"));
    	Console.WriteLine (TrimLastPart("http://stackoverflow.com/questions/ask//randomcrap.html"));
    }
    enum State
    {
    	SlashNotEncountered,
    	SlashEncountered,
    	BuildingResult
    }
    
    string TrimLastPart(string input)
    {
    	string result = string.Empty;
    	State state = State.SlashNotEncountered;	
    	foreach (var c in input.ToCharArray().Reverse())
    	{
    		switch (state)
    		{
    			case State.SlashNotEncountered:
    				if(c == '/')
    				{
    					state = State.SlashEncountered;
    				}
    				break;	
    			case State.SlashEncountered:
    				if(c != '/')
    				{
    					state = State.BuildingResult;
    					result = c.ToString();
    				}
    				break;	
    			case State.BuildingResult:
    				result = c + result;
    				break;
    		}
    	}
    	return result + "/";
    }
    
        
