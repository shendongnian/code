    using System;
    using System.Linq;
    using System.Web.Script.Serialization;
    using System.Xml.Linq;
    
    class Program
    {
        static void Main()
        {
            var xml = 
            @"<Columns>
              <Column Name=""key1"" DataType=""Boolean"">True</Column>
              <Column Name=""key2"" DataType=""String"">Hello World</Column>
              <Column Name=""key3"" DataType=""Integer"">999</Column>
            </Columns>";
            var dic = XDocument
                .Parse(xml)
                .Descendants("Column")
                .ToDictionary(
                    c => c.Attribute("Name").Value, 
                    c => c.Value
                );
            var json = new JavaScriptSerializer().Serialize(dic);
            Console.WriteLine(json);
        }
    }
