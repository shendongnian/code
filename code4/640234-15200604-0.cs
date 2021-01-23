    public string NoSimilarChar(string password)
    {
        string[] charsToRemove = new  string[] { "l", "i", "1", "0", "O" }
        foreach (string charToRemove in charsToRemove)
        {
            if(password.Contains(charToRemove))
                password = password.Replace(charToRemove, "");
        }
        return password;
    }
