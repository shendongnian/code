    	public string toDecimalString()
    {
    	StringBuilder b = new StringBuilder(9 * digits.Length);
    	var str = digits[0].ToString("D");
    	b.Append(str);
    	for (int i = 1; i < digits.Length; i++)
    	{
    		var str2 = digits[i].ToString("D9");
    		b.Append(str2);
    	}                
    	return b.ToString();
    }
