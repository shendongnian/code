    public static bool isValidUrl(ref string url)
    {
        string pattern = @"^(http|https|ftp)\://[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$";
        Regex reg = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
        return reg.IsMatch(url);
    }
