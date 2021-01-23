    class Program
    {
        static void Main(string[] args)
        {
            RemoveHyperlinksButKeepText();
        }
    
        private static void RemoveHyperlinksButKeepText()
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.Load(@"C:\Libs\HtmlAgilityPack.1.4.0\YourHtmlFile.html");
    
            var links = htmlDoc.DocumentNode.SelectNodes("//a");
    
            string html = htmlDoc.DocumentNode.OuterHtml;
    
            foreach (HtmlNode link in links)
            {
                var linkText = link.InnerText;
    
                html = html.Replace(link.OuterHtml, linkText);
            }
    
        }
    }
