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
    Console.WriteLine(builder.Query); //correct query with cyrillic stuff encoded once
    
    var uri = builder.Uri; // creates new Uri using constructor which does encode and messes cyrillic parameter
    Console.WriteLine(uri);
    // this is still wrong:
    var stringUri = builder.ToString(); // returns correct Uri, well this is quite inconsistent, but exactly what we want
    new HttpClient().GetStringAsync(stringUri); // this creates Uri object out of 'stringUri' so we still end up sending double encoded cyrillic text to server. Ouch!
