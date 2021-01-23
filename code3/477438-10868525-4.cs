    public string GetFirstFromSplit(string input, char delimiter)
    {
        var i = input.IndexOf(delimiter);
        
        return i == -1 ? input : input.Substring(0, i);
    }
