    string[] delimiters = { "del1", "del2", "del3" };
    
    string input = "text1del1text2del2text3del3";
    string[] parts = input.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
    
    for(int index = 0; index < parts.Length; index++)
    {
        string part = parts[index];
        string temp = input.Substring(input.IndexOf(part) + part.Length);
    
        foreach (string delimter in delimiters)
        {
            if ( temp.IndexOf(delimter) == 0)
            {
                parts[index] += delimter;
                break;
            }
        }
    }
