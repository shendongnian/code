    Char[] splitChars = {'A', 'B', etc....}; //what the string will be split by
    string desc = inputString; // input string
    string[] splitByCapital = desc.Split(splitChars);
    string[] output = new string[splitByCapital.length];
    for (int i = 0; i < splitByCapital.length; i++)
    {
    	if (splitByCapital[i].Contais("-"))
    	{
    		output = splitByCapital[i] + splitByCapital[i-1];
    	}
    	else
    	{
    		output = splitByCapital[i];
    	}
    }
