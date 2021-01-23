    public static String ParseCapitalize(this String str)
    {
        if (str.StartsWith("_"))
        {
            if (str.Length > 1)
            {
                return str.Substring(1, 1).ToUpper() + (str.Length > 2 ? str.Substring(2) : "");
            }
            else
            {
                return "";
            }
        }
        return str;
    }
    //Usage:
    String s = "_this is a string";
    if(!String.IsNullOrEmpty(s))
        s = s.ParseCapitalize();
