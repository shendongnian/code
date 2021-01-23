    public static Dictionary<int, String> Chop(this string str, int minLength)
    {
        if (str == null) throw new ArgumentException("str");
        if (str.Length < minLength) throw new ArgumentException("Length of string less than minLength", "minLength");
        var dict = str.TakeWhile((c, index) => index <= str.Length - minLength)
            .Select((c, index) => new { 
                Index = index, 
                Value = str.Substring(0, minLength + index) 
            }).ToDictionary(obj => obj.Index, obj => obj.Value);
        return dict;
    }
