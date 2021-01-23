    public static List<string> ParseFreePlace(string response, string level)
    {
       if (string.IsNullOrWhiteSpace(response)) return new List<string>();
    
       return 
       		XDocument.Parse(response)
    				 .Descendants("Place")
    				 .Select(e =>
    				 	String.Format("r={0};p={1};f={2};l={3};",
    					               e.Attribute("Row").Value,
    					               e.Attribute("Place").Value,
    					               e.Attribute("Fragment").Value,
    					               level)
    				 ).ToList();
    }
