    using HtmlAgilityPack;
    
    namespace WebScraper
    {
        class Program
        {
            static void Main(string[] args)
            {
                HtmlWeb web = new HtmlWeb();
                HtmlDocument doc =web.Load(url);
                foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@Link]"))
                {
                }
