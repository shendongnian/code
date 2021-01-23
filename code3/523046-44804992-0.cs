    var values = new JObject();
    
    foreach (var raw_header in request.Headers
                                       .ToString()
                                       .Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries))
    {
        var index = raw_header.IndexOf(':');
        if (index <= 0)
            continue;
    
        var key = raw_header.Substring(0, index);
        var value = index + 1 >= raw_header.Length ? string.Empty : raw_header.Substring(index + 1).TrimStart(' ');
    
        values.Add(new JProperty(key, value));
    }
