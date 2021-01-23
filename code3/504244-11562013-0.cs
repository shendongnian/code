    protected void Page_Load(object sender, EventArgs e)
    {
          List<HtmlAgilityPack.HtmlNode> test = GetInnerTest();
    
          foreach (var node in test)
          {
                Response.Write("Result: " + node.InnerHtml.ToString());
          }
    
    }
    
    public List<HtmlAgilityPack.HtmlNode> GetInnerTest()
    {
         HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    
         doc.OptionFixNestedTags = true;
         doc.Load(requestData("http://leagueoflegends.wikia.com/wiki/List_of_champions"));
    
         var node = doc.DocumentNode.Descendants("span").Where(d => d.Attributes.Contains("class") && d.Attributes["class"].Value.Contains("character_icon")).ToList();
    
         return node;
    }
    
    
    public StreamReader requestData(string url)
    {
           HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
           HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
    
           StreamReader sr = new StreamReader(resp.GetResponseStream());
    
           return sr;
    }
