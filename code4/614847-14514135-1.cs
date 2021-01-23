    using HtmlAgilityPack;
    
    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    List<string> href = new List<string>();
    
    private void addHREF()
    {
        //put your input to check
        string input = "";
                
        doc.LoadHtml(input);
        //Which files ignore?
        string[] stringArray = { ".png", ".jpg" };
        foreach (var item in doc.DocumentNode.SelectNodes("//a"))
        {
            string value = item.Attributes["href"].Value;
            if (stringArray.Any(value.Contains) == false)
                href.Add(value);
        }
    }
