    var builder = new UriBuilder
    {
        Scheme = Uri.UriSchemeHttps,
        Port = -1,
        Host = "127.0.0.1",
        Path = "app"
    };
    
    NameValueCollection query = HttpUtility.ParseQueryString(builder.Query);
    
    query["cyrillic"] = "кирилиця";
    
    builder.Query = query.ToString();
    Console.WriteLine(builder.Query);
    
    var uri = builder.Uri; // creates new Uri using constructor which does encode
    Console.WriteLine(uri);
