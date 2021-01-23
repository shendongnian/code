    public static IEnumerable<string> GetCharsAsStrings(this string value)
    {
        return value.Select(c =>
               {
                    //not good at all, but also a working variant
                    //return string.Concat(c);
                    return c.ToString();
               });
    }
