    bool IsCorrect(string s)
    {
    	string[] split = s.split(':');
    	int number1, number2;
    	if (split.Length == 2 && split[0].Length == 5 && split[1].Length == 5)
    	{
    		if (int.TryParse(split[0], out number1) && int.TryParse(split[1], out number2) && number1 <= number2)
    		{
    			return true;
    		}
    	}
    	return false;
    }
