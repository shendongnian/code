    public static string Concatenate<T, U>(this IEnumerable<T> source, Func<T, U> selector, string separator = ", ")
    {
        if (source == null)
        {
            return string.Empty;
        }
        return source
            .Select(selector)
            .Concatenate(separator);
    }
    public static string Concatenate<T>(this IEnumerable<T> source, string separator = ", ")
    {
        if (source == null)
        {
            return string.Empty;
        }
        StringBuilder sb = new StringBuilder();
        bool firstPass = true;
        foreach (string item in source.Distinct().Select(x => x.ToString()))
        {
            if (firstPass)
            {
                firstPass = false;
            }
            else
            {
                sb.Append(separator);
            }
            sb.Append(item);
        }
        return sb.ToString();
    }
