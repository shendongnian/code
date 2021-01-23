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
              <Column Name=""key1"" DataType=""System.Boolean"">True</Column>
              <Column Name=""key2"" DataType=""System.String"">Hello World</Column>
              <Column Name=""key3"" DataType=""System.Int32"">999</Column>
            </Columns>";
            var dic = XDocument
                .Parse(xml)
                .Descendants("Column")
                .ToDictionary(
                    c => c.Attribute("Name").Value, 
                    c => Convert.ChangeType(
                        c.Value,
                        typeof(string).Assembly.GetType(c.Attribute("DataType").Value, true)
                    )
                );
            var json = new JavaScriptSerializer().Serialize(dic);
            Console.WriteLine(json);
        }
    }
