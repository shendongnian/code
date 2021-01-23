    string query = System.Web.HttpUtility.UrlDecode(input);
    NameValueCollection result = System.Web.HttpUtility.ParseQueryString(query);
    foreach (var key in result.AllKeys)
    {
        var value = result[key];
        Console.WriteLine("{0}: {1}", key, value);
    }
