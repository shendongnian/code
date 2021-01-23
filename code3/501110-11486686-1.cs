    private bool HasSwearWord(string text)
    {
        // Splits words, removes whitespace and any punctuation
        string[] wordArray = Regex.Split(text, @"\W+");
    
        // Check if any word in the string is a swear word
        foreach (string word in wordArray)
        {
            if (swearWords.Contains(word.ToLower()))
            {
                return true;
            }
        }
        return false;
    }
