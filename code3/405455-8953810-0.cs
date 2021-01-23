    Uri uri = new Uri(urlString);
    NameValueCollection outer = HttpUtility.ParseQueryString(uri.Query);
    string k = outer["k"];
    string decoded = HttpUtility.UrlDecode(k);
    var matches = Regex.Matches(decoded, @"(?<key>\w+):(?<value>.*?)(?= \w+:|$)");
    IDictionary<string, string> dic = matches.Cast<Match>().ToDictionary(m => m.Groups["key"].Value, m => m.Groups["value"].Value);
