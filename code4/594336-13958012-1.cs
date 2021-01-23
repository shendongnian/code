    const string validChars = "abcdefghijklmenopqrstuvwxyz";
    
    List<string> GetAllWords(string inputSentence)
    {
        var list = new List<string>();
    	
    	string word = string.Empty;
        foreach (var c in inputSentence.ToLower())
        {
        	if (validChars.IndexOf(c) >= 0)
    		{
    			word += c;
    		}
    		else if (word != string.Empty)
    		{
    			list.Add(word);
    			word = string.Empty;
    		}
        }
    	
    	return list;
    }
