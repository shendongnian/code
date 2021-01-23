    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    public class Test
    {
        static void Main()
        {
            string xml = "<Ids><id>1</id><id>2</id></Ids>";
    
            XDocument doc = XDocument.Parse(xml);
    
            List<string> list = doc.Root.Elements("id")
                               .Select(element => element.Value)
                               .ToList();
    
            
        }
    }
