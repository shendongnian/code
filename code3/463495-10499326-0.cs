    string answer = "hotel"
    if (answer.EqualsAny("house", "hotel", "appartment"))
    {
        DoSomething()
    }
    // Extending the thought to another version
    if (answer.EqualsAll("house", "hotel", "appartment"))
    {
        DoSomething()
    }
    public static class Extensions
    {
        public static bool EqualsAny(this string value, params string[] compareAgainst)
	    {
    	    foreach (var element in compareAgainst)
	        {
		        if(value == element)
			       return true;
		    }
     		return false;
	    }
        public static bool EqualsAll(this string value, params string[] compareAgainst)
	    {
		    foreach (var element in compareAgainst)
		    {
			    if(value != element)
			    	return false;
		    }
		    return true;
	    }
    }
