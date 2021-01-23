    public void WordFinder()
    {
    	bool isWord = false;
    	Random rnd = new Random();
    	string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "n", "p", "q", "r", "s", "t", "v", "w", "x", "y", "z" };
    	string[] vowels = { "a", "e", "i", "o", "u" };
    
    
    	while (isWord == false)
    	{
    		string word = "";
    
    		Console.WriteLine("Pick the length of a word");
    		int requestedLength = Convert.ToInt32(Console.ReadLine());
    
    		// Generate the word in consonant / vowel pairs
    		while (word.Length < requestedLength)
    		{
    			if (requestedLength != 1)
    			{
    				// Add the consonant
    				string consonant = GetRandomLetter(rnd, consonants);
    
    				if (consonant == "q" && word.Length + 3 <= requestedLength) // check +3 because we'd add 3 characters in this case, the "qu" and the vowel.  Change 3 to 2 to allow words 
    				{
    					word += "qu";
    				}
    				else
    				{
    					while( consonant == "q")
    					{
    						// Replace an orphaned "q"
    						consonant = GetRandomLetter(rnd, consonants); 
    					}
    
    					if (word.Length + 1 <= requestedLength)
    					{
    						// Only add a consonant if there's enough room remaining
    						word += consonant;
    					}
    				}
    			}
    
    			if (word.Length + 1 <= requestedLength)
    			{
    				// Only add a vowel if there's enough room remaining
    				word += GetRandomLetter(rnd, vowels);
    			}
    		}
    
    		Console.WriteLine(word);
    		Console.WriteLine("Is this a word? (y/n)");
    		string q = Console.ReadLine().ToLower();
    
    		if (q == "y" || q == "yes")
    		{
    			isWord = true;
    		}
    	}
    }
    
    private static string GetRandomLetter(Random rnd, string[] letters)
    {
    	return letters[rnd.Next(0, letters.Length - 1)];
    }
