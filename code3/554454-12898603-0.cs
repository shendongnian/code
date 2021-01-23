    namespace ConsoleApplication6
    {
        class Program
        {
            static void Main(string[] args)
            {
                var parent = XElement.Parse("<tag>Alice &amp; Bob<other>cat</other></tag>");
                var nodes = from x in parent.Nodes()
                                where x.NodeType == XmlNodeType.Text
                                select (XText)x;
    
                foreach (var val in nodes)
                {
                    Console.WriteLine(val.Value);
                }
                Console.ReadLine();
            }
        }
    }
