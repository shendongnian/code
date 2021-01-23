    public static string Replace(string Word, string oldChar, string newChar)
    {
    	for (int i = 0; i < Word.Length; i++)
    	{
    		string aux = "" + Word[i];
    		if (aux.Equals(oldChar))
    		{
    			Word = Word.Remove(i, 1);
    			Word = Word.Insert(i, newChar);
    
    			return Word;
    		}
    	}
    	return Word;
    }
