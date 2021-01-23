    using System;
    using System.Linq;
    using HtmlAgilityPack;
    public class Program
    {
        static void Main()
        {
            var document = new HtmlDocument();
            document.Load("test.html");
            var links =
                from element in document.DocumentNode.Descendants()
                let href = element.Attributes["href"]
                let src = element.Attributes["src"]
                where href != null || src != null
                select href != null ? href.Value : src.Value;
    
            foreach (var link in links)
            {
                Console.WriteLine(link);
            }
        }
    }
