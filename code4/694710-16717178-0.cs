    using System.Linq;
    using System.Xml.Linq;
    class Test
    {
    
        static void Main()
        {
            XDocument document = XDocument.Load("test.xml");
            Swap("name3", "name6", document);
            document.Save("test.xml");
        }
    
        static void Swap(string nameOne, string nameTwo, XDocument document)
        {
            var nameOneNode = document.Descendants("var").FirstOrDefault(p => p.Attribute("name").Value == nameOne);
            var nameTwoNode = document.Descendants("var").FirstOrDefault(p => p.Attribute("name").Value == nameTwo);
            nameOneNode.Attribute("name").Value = nameTwo;
            nameTwoNode.Attribute("name").Value = nameOne;
        }
    }
