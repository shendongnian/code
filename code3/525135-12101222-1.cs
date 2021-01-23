    class Program
    {
        static void Main(string[] args)
        {
            RemoveHyperlinksButKeepText();
        }
    
        private static void RemoveHyperlinksButKeepText()
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.Load(@"C:\YourHtmlFile.html");
    
            var links = htmlDoc.DocumentNode.SelectNodes("//a");
    
            string html = htmlDoc.DocumentNode.OuterHtml;
    
            foreach (HtmlNode link in links)
            {
                var linkText = link.InnerText;
    
                html = html.Replace(link.OuterHtml, linkText);
            }
    
        }
    }
