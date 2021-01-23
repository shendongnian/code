    private int counter = 0;
    private List<string> links;
    private List<string> titles;
    private void Initialize()
    {
        links = new List<string>();
        titles = new List<string>();
        const string url = "http://reddit.com/r/pics";
        var source = getSource(url);
        var regex = new Regex([regex removed]);
        foreach (Match match in regex.Matches(source))
        {
            links.Add(match.Groups[1].Value);
            titles.Add(match.Groups[2].Value);
        }
    }
