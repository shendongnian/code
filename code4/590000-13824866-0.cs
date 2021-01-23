    Hashset<char> lstAllowedCharacters = new Hashset<char>{'a','b','c','2',' '};
    
    var resultStrBuilder = new StringBuilder(srVariable.Length);
    
    foreach (char c in srVariable) 
    {
    	if (lstAllowedCharacters.Contains(c))
    	{
    		resultStrBuilder.Append(c);
    	}
    	else
    	{
    		resultStrBuilder.Append(" ");
    	}
    }
    
    srVariable = resultStrBuilder.ToString();
