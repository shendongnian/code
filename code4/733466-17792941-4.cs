    public bool ValidName(string dirName)
    {
        char[] reserved = Path.GetInvalidFileNameChars();
        
        if (dirName.Length < 3)
             return false;
        if (dirName > 20)
             return false;
    
        foreach (char c in reserved)
        {
             if (dirName.Contains(c))
                 return false;
        }
    
        return true;
    }
