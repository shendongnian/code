    static string ConvertToMyStyle(List<string> input)
    {
    	string result = "";
    			
    	foreach(string item in input)
    	{
    		if(input.IndexOf(item) != input.ToArray().Length-1)
    			result += item + ", ";
    		else
    			result += "and " + item + ".";
    	}
    	return result;
    }
