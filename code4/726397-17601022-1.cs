    if (!Regex.IsMatch(line, "https?:\/\/"))
        line = "http://" + line;
    Uri uri;
    if (Uri.TryCreate(line, UriKind.Absolute, out uri))
    {
        // it's a valid url.
        host = uri.Host;
    }
