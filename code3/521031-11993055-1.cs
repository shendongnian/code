    public string BuildLists(List<KeyValuePair<string, int>> pairs)
    {
    	int CurrentLevel = 1;
    	StringBuilder s = new StringBuilder();
    	
    	s.Append("<ul>");
    	
    	foreach (KeyValuePair pair in pairs)
    	{
    		if(pair.Value > CurrentLevel)
    		{
    			//Nest more
    			for(int i = 0; i < pair.Value - CurrentLevel; i++)
    			{
    				s.Append("<li><ul>");
    			}
    		}
    		else if(pair.Value < CurrentLevel)
    		{
    			//Close Tags
    			for(int i = 0; i < CurrentLevel - pair.Value; i++)
    			{
    				s.Append("</ul></li>");
    			}
    		}
    		
    		s.Append("<li>" + pair.Key + "</li>");
    	
    		CurrentLevel = pair.Value
    	}
    	
    	s.Append("</ul>");
    	return s.ToString();
    }
