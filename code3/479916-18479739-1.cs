    public static Dictionary<string, string> ParseQueryString(Uri uri)
    {
        var substring = uri.Query;
        if (substring.Length > 0)
             substring.Substring(1);
        var pairs = substring.Split('&'); 
        var output = new Dictionary<string, string>(pairs.Length);
            
        foreach (string piece in pairs)
        {
            var pair = piece.Split('=');
            output.Add(
                Uri.UnescapeDataString(pair[0]),
                Uri.UnescapeDataString(pair[1]));
        }
        return output;
    }
