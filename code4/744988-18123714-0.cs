    using System;
    using System.IO;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;
    using HtmlAgilityPack;
    class Program
    {
        static void Main(string[] args)
        {
            var whiteList = new[] 
                { 
                    "#comment", "html", "head", 
                    "title", "body", "img", "p",
                    "a"
                };
            var html = File.ReadAllText("input.html");
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            var nodesToRemove = new List<HtmlAgilityPack.HtmlNode>();
            var e = doc
                .CreateNavigator()
                .SelectDescendants(System.Xml.XPath.XPathNodeType.All, false)
                .GetEnumerator();
            while (e.MoveNext())
            {
                var node =
                    ((HtmlAgilityPack.HtmlNodeNavigator)e.Current)
                    .CurrentNode;
                if (!whiteList.Contains(node.Name))
                {
                    nodesToRemove.Add(node);
                }
            }
            nodesToRemove.ForEach(node => node.Remove());
            var sb = new StringBuilder();
            using (var w = new StringWriter(sb))
            {
                doc.Save(w);
            }
            Console.WriteLine(sb.ToString());
        }
    }
