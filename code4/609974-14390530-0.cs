    public static string functionToGetFormated(this IEnumerable<string> input)
    {
        StringBuilder sb = new StringBuilder();
        foreach (string s in input)
        {
            sb.AppendFormat("<td>{0}</td>", s);
        }
        return sb.ToString();
    }
