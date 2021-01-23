    public static string ChangeSPChart(string sTheInput)
    {
    	StringBuilder sRetMe = new StringBuilder(sTheInput);
    
    	sRetMe.Replace('+', '-');
    	sRetMe.Replace('/', '*');
    	sRetMe.Replace('=', '!');
    
    	return sRetMe.ToString();
    }
    
    public static string FixSPChart(string sTheInput)
    {
    	StringBuilder sRetMe = new StringBuilder(sTheInput);
    
    	sRetMe.Replace('-', '+');
    	sRetMe.Replace('*', '/');
    	sRetMe.Replace('!', '=');
    
    	return sRetMe.ToString();
    }
