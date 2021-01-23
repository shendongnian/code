    public static string MultiplyBy(this string s, int times)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < times; i++)
        {
            sb.Append(s);
        }
        return sb.ToString();
    }
