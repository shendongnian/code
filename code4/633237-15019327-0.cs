    private static void parseFile(string fileName)
    {
    	string content = File.ReadAllText(fileName, Encoding.UTF8);
    	foreach (char character in content)
    	{
    		if (character >= 'A' && character <= 'Z')
    		{
    			// handle A-Z
    		}
    		else if (character >= 'a' && character <= 'z')
    		{
    			// handle a-z
    		}
    		else if (character >= '0' && character <= '9')
    		{
    			// handle 0-9
    		}
    		else
    		{
    			// handle everything else
    		}
    	}
    }
