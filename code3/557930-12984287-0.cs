    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using HtmlAgilityPack;
    
    namespace HTMLAgilityExample
    {
        class Program
        {
            static void Main(string[] args)
            {
                string contentValue;
                
                HtmlDocument document = new HtmlDocument();
                document.Load("C:/test.html");
                foreach(HtmlNode link in document.DocumentNode.SelectNodes("//meta[@content]"))
                {
                    HtmlAttribute attribute = link.Attributes["content"];
                    if(attribute.Value.Contains("WordPress"))
                    {
                        contentValue = attribute.Value.Replace("WordPress", "").Trim();
                    }
                }
            }
        }
    }
