    public int MakeUnique(string s)
    {
        string result = "";
    
        foreach(var c in s)
        {
            result += ((int)c).ToString();
        }
    
        return Int.Parse(result);
    }
