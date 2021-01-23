    public static String ParseCapitalize(this String str)
    {
        if (str.Length > 1 && str.StartsWith("_"))
            return str.Substring(1, 1).ToUpper() + (str.Length > 2 ? str.Substring(2) : "");
        return null;
    }
    //Usage:
    String s = "_this is a string";
    if(!String.IsNullOrEmpty(s))
        s = s.ParseCapitalize();
