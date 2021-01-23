    public static string ToEngV(this double d, int digits, bool round)
    {
    	var lenght = Math.Truncate(d).ToString().Length;
    
    	if (lenght > digits)
    	{
    		throw new ArgumentException("...");
    	}
    
    	int decimals = digits - lenght;
    
    	if (round)
    	{
    		return Math.Round(d, decimals).ToString();
    	}
    	else
    	{
    		int pow = (int)Math.Pow(10, decimals);
    		return (Math.Truncate(d * pow) / pow).ToString();
    	}
    }
