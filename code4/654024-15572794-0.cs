    static void Main()
    {
        var values = new NameValueCollection();
        values["artist"] = "singer1 & singer2";
        values["song"] = "name song";
        Console.WriteLine(CreateQueryString(values));
    }
    static string CreateQueryString(NameValueCollection values)
    {
        if (values == null) { throw new ArgumentNullException("values"); }
        return string.Join(
            "&",
            values.AllKeys.Select(key => HttpUtility.UrlEncode(key) + "=" +
                                         HttpUtility.UrlEncode(values[key]))
                          .ToArray());
    }
