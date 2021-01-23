    private static string ScrambleWord(string word)
    {
        // easy exits come first
        if (string.IsNullOrEmpty(word))
            return String.Empty;
    
        if (word.Length <= 3)
            return word;
    
        // now do the work
        StringBuilder builder = new StringBuilder();
        Random rand = new Random();
    
        builder.Append(word.Substring(0, 1));
    
        List<Char> parts = word.Substring(1).ToList();
    
        while (parts.Count() > 0)
        {
            int upper = parts.Count();
            int index = rand.Next(0, upper);
            builder.Append(parts[index]);
            parts.RemoveAt(index);
        }
    
        return builder.ToString();
    }
