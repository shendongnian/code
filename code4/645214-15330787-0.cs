    public static string RemoveWhiteSpaces(this string str)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < str.Length; i++)
        {
            if(!Char.IsWhiteSpace(str, i)){
               sb.Append(str[i]);
            }
        }
        return sb.ToString();
    }
