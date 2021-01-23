    private int counter = 0;
    private List<string> links = new List<string>();
    private List<string> titles = new List<string>();
    private void initialize()
    {
        const string url = "http://reddit.com/r/pics";
        var source = getSource(url);
        var regex = new Regex([regex removed]);
        foreach (Match match in regex.Matches(source))
        {
            links.Add(match.Groups[1].Value);
            titles.Add(match.Groups[2].Value);
        }
    }
    private void frontPageToolStripMenuItem_Click(object sender, EventArgs e)
    {
        label1.Text = titles[(counter++) % titles.Count];
    }
