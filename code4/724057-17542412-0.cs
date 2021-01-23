    using System.Xml.Linq;
    class Program
    {
        static void Main(string[] args)
        {
            var xDoc = XDocument.Load("xml.xml");
            var ordered = xDoc.Root.Elements()
                .OrderBy(i => Convert.ToInt32(i.Name.LocalName.Split('-')[1]))
                .ThenBy(i => Convert.ToInt32(i.Name.LocalName.Split('-')[2]))
                .ToList();
            xDoc.Root.ReplaceAll(ordered);
            xDoc.Save("xml_1.xml");
        }
    }
