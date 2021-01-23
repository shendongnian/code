    public List<string> GetLinks(string message)
    {
        List<string> list = new List<string>();
        Regex urlRx = new Regex(@"((https?|ftp|file)\://|www.)[A-Za-z0-9\.\-]+(/[A-Za-z0-9\?\&\=;\+!'\(\)\*\-\._~%]*)*", RegexOptions.IgnoreCase);
        MatchCollection matches = urlRx.Matches(message);
        foreach (Match match in matches)
        {
            list.Add(match.Value);
        }
        return list;
    }
    var list = GetLinks("Hey yo check this: http://www.google.com/?q=stackoverflow and this: http://www.mysite.com/?id=10&author=me");
