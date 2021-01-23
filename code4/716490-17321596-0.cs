    public static Array StringToArray(string str)
    {
        return str.Replace(" ", ",").Split(',');
    }
    public static string ArrayToString(Array array)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i <= array.Length-1; i++)
        {
            var format = "{0},"; // separate with comma if even number
            if (i % 2 != 0)
                format = "{0} "; // separate with space if odd
            sb.Append(format, array[i]);
        }
        return sb.ToString();
    }
