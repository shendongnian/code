    public static string UpperCaseUrlEncode(this string s)
    {
        char[] temp = HttpUtility.UrlEncode(s).ToCharArray();
        for (int i = 0; i < temp.Length - 2; i++)
        {
            if (temp[i] == '%')
            {
                temp[i + 1] = char.ToUpper(temp[i + 1]);
                temp[i + 2] = char.ToUpper(temp[i + 2]);
            }
        }
        return new string(temp);
    }
