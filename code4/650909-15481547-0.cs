    public static List<T> ParseDelimitedList<T>(this string value, string delimiter, Func<string, T> selector)
    {
        if (value == null)
        {
            return new List<T>();
        }
        var output = value.Split(new string[] { delimiter }, StringSplitOptions.RemoveEmptyEntries);
        return output.Select(selector).ToList();
    }
    var list = "1,2,3".ParseDelimitedList(",", s => int.Parse(s));
