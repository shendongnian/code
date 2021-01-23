    protected void Page_Load(object sender, EventArgs e)
    {
        string url = "http://www.metacritic.com/game/pc/halo-spartan-assault";
        var web = new HtmlAgilityPack.HtmlWeb();
        HtmlDocument doc = web.Load(url);
    
        string metascore = doc.DocumentNode.SelectNodes("//*[@id=\"main\"]/div[3]/div/div[2]/div[1]/div[1]/div/div/div[2]/a/span[1]")[0].InnerText;
        string userscore = doc.DocumentNode.SelectNodes("//*[@id=\"main\"]/div[3]/div/div[2]/div[1]/div[2]/div[1]/div/div[2]/a/span[1]")[0].InnerText;
        string summary = doc.DocumentNode.SelectNodes("//*[@id=\"main\"]/div[3]/div/div[2]/div[2]/div[1]/ul/li/span[2]/span/span[1]")[0].InnerText;
    }
