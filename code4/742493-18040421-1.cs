    // If you want the search/replace to be case sensitive, remove the 
    // StringComparer.OrdinalIgnoreCase
    Dictionary<string, string> replaces = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase) { 
        // The format is word to be searched, word that should replace it
        // or String.Empty to simply remove the offending word
        { "why", "xxx" }, 
        { "you", "yyy" },
    };
    
    void Main()
    {
    	string a = "why and you it and You it";
        // This will search for blocks of letters and numbers (abc/abcd/ab1234)
        // and pass it to the replacer
    	string b = Regex.Replace(a, @"\w+", Replacer);
    }
    
    string Replacer(Match m)
    {
    	string found = m.ToString();
    	
    	string replace;
    
        // If the word found is in the dictionary then it's placed in the 
        // replace variable by the TryGetValue
    	if (!replaces.TryGetValue(found, out replace))
    	{
            // otherwise replace the word with the same word (so do nothing)
    	    replace = found;
    	}
    	else
    	{
            // The word is in the dictionary. replace now contains the
            // word that will substitute it.
    	    // At this point you could add some code to maintain upper/lower 
            // case between the words (so that if you -> xxx then You becomes Xxx
            // and YOU becomes XXX)
    	}
    	return replace;
    }
