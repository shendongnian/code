    // Remove all accents
    var bytes = Encoding.GetEncoding("Cyrillic").GetBytes(text);
    text = Encoding.ASCII.GetString(bytes);
    
    // Remove all unwanted characters
    var regex = new Regex("[^a-zA-Z0-9-]");
    text = regex.Replace(text, "");
