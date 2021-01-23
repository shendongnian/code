    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
            populate();
    }
    
    private void populate()
    {
        litCode.Text = getSoureCodeFromFile("http://localhost:21300/Search.aspx");
    }
    
    private string getSoureCodeFromFile(string url)
    {
        string r = "";
        using (WebClient wc = new WebClient())
        {
            r = wc.DownloadString(url);
        }
        return r;
    }
