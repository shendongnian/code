    public static String[] Split(String txt, char[] delim)
    {
        if (txt == null)
            return new String[0]; // or exception
        if (delim == null || delim.Length == 0)
            return new String[0]; // or exception
    
        char[] text = txt.ToCharArray();
        string[] result = new string[1]; // If there is no delimiter in the string, return the whole string
        int part = 0;
        int itemInArray = 1;
    
        for (int i = 0; i < text.Length; i++)
        {
            if (IsIn(delim, text[i]))
            {
                Array.Resize(ref result, ++itemInArray); // Is it consider as a framework method ???
                part++;
            }
            else
                result[part] += text[i];
        }
        return result;
    }
    public static Boolean IsIn(char[] delim, char c)
    {
        for (int i = 0; i < delim.Length; i++)
            if (c == delim[i])
                return true;
        return false;
    }
