    public string IncrementString(string value)
    {
        if (string.IsNullOrEmpty(value)) return "a";
        var chars = value.ToArray();
        var last = chars.Last();
     
        if(char.ToByte() == 122)
        return value + "a";
        
        return value.SubString(0, value.Length) + (char)(char.ToByte()+1);
    }
