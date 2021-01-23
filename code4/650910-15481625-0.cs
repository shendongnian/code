    public static List<T> ToDelimitedList<T>(this string value, string delimiter, Func<string, T> converter)
    {
        if (value == null)
        {
            return new List<T>();
        }
    
        var output = value.Split(new string[] { delimiter }, StringSplitOptions.RemoveEmptyEntries);
        return output.Select(converter).ToList();
    }
