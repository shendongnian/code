    public static string WrapElementsWithTag(this IEnumerable<string> input, string wrapper)
    {
        StringBuilder sb = new StringBuilder();
        foreach (string s in input)
        {
            sb.AppendFormat("<{1}>{0}</{1}>", s, wrapper);
        }
        return sb.ToString();
    }
