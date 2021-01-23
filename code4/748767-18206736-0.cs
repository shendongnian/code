    using System.Xml.Linq;
    using System.Xml.XPath;
    class Program
    {
        static void Main(string[] args)
        {
            var xdoc = XDocument.Load("input.xml");
            var subTopic = xdoc
                .XPathSelectElement("//Topic[@Name='creatingTests']/SubTopic");
        }
    }
