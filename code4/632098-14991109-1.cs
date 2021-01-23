    using HtmlAgilityPack;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
               
                HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
                document.Load("page.html");
    
                List<HtmlNode> x = document.GetElementbyId("table2").Elements("tr").ToList();
    
                foreach (HtmlNode node in x)
                {
                    List<HtmlNode> s = node.Elements("td").ToList();
                    foreach (HtmlNode item in s)
                    {
                        Console.WriteLine("TD Value: " + item.InnerText);
                    }
                }
                Console.ReadLine();
            }
        }
    }
