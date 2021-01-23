    HtmlDocument doc = new HtmlDocument();
    doc.Load(myHtmlFile);
    
        foreach (HtmlNode p in doc.DocumentNode.SelectNodes("//div"))
        {
            if(p.attribute["id"].Value == "content")
            {
                foreach(HtmlNode child in p.ChildNodes.SelectNodes("//ul"))
                {
                    if(p.PreviousSibling.InnerText() == "Header")
                    {
                        foreach(HtmlNode liNodes in p.ChildNodes)
                        {
                            //liNodes represent all childNode
                        }
                    }
            }
        }
