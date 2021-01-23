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
    Console.WriteLine(builder.Query); //query with cyrillic stuff UrlEncodedUnicode, and that's not what you want
    
    var uri = builder.Uri; // creates new Uri using constructor which does encode and messes cyrillic parameter even more
    Console.WriteLine(uri);
    // this is still wrong:
    var stringUri = builder.ToString(); // returns more 'correct' (still `UrlEncodedUnicode`, but at least once, not twice)
    new HttpClient().GetStringAsync(stringUri); // this creates Uri object out of 'stringUri' so we still end up sending double encoded cyrillic text to server. Ouch!
