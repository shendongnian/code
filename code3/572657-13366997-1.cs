    using System.Xml.Linq;
    using System.Xml.XPath;
    
    public class Program
    {
        public static void Main(string[] args)
        {
            var doc = XDocument.Parse(XML);
            foreach(var n in doc.Root.XPathSelectElements(
                     @"//products/product/id[text()='2']"))
            {
                System.Console.WriteLine("Not that hard: '{0}'", n.Parent.Element("name").Value);
            }
            // Direct query for name:
            foreach(var n in doc.Root.XPathSelectElements(
                     @"//products/product/id[text()='2']/../name"))
            {
                System.Console.WriteLine("Directly: '{0}'", n.Value);
            }
        }
    
        private const string XML = 
        @"<?xml version=""1.0"" encoding=""utf-8""?>
            <products>
                <product>
                    <id>1</id>
                    <name>John</name>
                </product>
                <product>
                    <id>2</id>
                    <name>Tom</name>
                </product>
                <product>
                    <id>3</id>
                    <name>Sam</name>
                </product>
            </products>";
    }
