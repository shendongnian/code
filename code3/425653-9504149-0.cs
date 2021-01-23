    using HtmlAgilityPack;    
    static void Main(string[] args)
        {
            HtmlDocument htmlDoc = new HtmlDocument();    
            htmlDoc.Load(@"c:\test.html");    
            var listofHyperLinkTags = from hyperlinks in htmlDoc.DocumentNode.Descendants()
                              where hyperlinks.Name == "a" &&
                                   hyperlinks.Attributes["href"] != null
                              select new
                              {
                                  Address = hyperlinks.Attributes["href"].Value,
                                  LinkTitle = hyperlinks.InnerText
                              };
    
            foreach(var linkDetail in listofHyperLinkTags)
                Console.WriteLine(linkDetail.LinkTitle + "[" + linkDetail.Address + "]");
                
            Console.Read();
        }
