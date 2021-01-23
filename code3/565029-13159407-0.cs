    public string TrimAtFirstChar(string s, char c)
    {
        int index = s.IndexOf(c);
        if(index == -1) //there is no '.' in the string
            return s;
        return s.Substring(0, index)
    }
