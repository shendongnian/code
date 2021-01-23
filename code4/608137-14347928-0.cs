    public static char Reverse(char c)
    {
    	if (Char.IsDigit(c))
    	{
    		return (char)((int)'9' - (int)c + (int)'0');
    	}
    	else
    	{
    		return (char)((int)'z' - (int)c + (int)'a');
    	}
    }
