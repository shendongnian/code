    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    class Program
    {
        static void Main(string[] args)
        {
            var xml = File.ReadAllText("input.xml");
            var ns = "DAV:";
            var doc = XDocument.Parse(xml);
            doc.Descendants(XName.Get("displayname", ns))
                .ToList().ForEach(dn =>
            {
                var isFolder = ((XElement)dn.NextNode).Value;
                var href = ((XElement)dn.Parent.Parent.PreviousNode).Value;
                Console.WriteLine("{0} {1} {2}", href, dn.Value, isFolder);
            });
        }
    }
