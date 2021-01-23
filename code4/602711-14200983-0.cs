    using System;
    using System.Linq;
    using System.Xml.Linq;
    class Program
    {
        static void Main(string[] args)
        {
            string xml = @"<root>
                            <brand name = 'ford'>   
                               <transport category='car'>
                                  <driver name='John, Doe'/>
                                  <driver name='Jane, Doe'/>
                                </transport>
                            </brand>
                            <brand name = 'opel'>
                               <transport category='car'>
                                  <driver name='Jerry, Smith'/>
                                  <driver name='Jeff, Perry'/>
                               </transport>
                            </brand></root>";
            XDocument doc = XDocument.Parse(xml);
            var transports = from t in doc.Root.Elements()
                             select new
                             {
                                 Category = t.Attribute("name").Value.Trim(),
                                 Drivers = t.Element("transport")
                                            .Elements()
                                            .Select(x => new { Name = x.Attribute("name").Value.Trim() })
                             };
            foreach (var t in transports)
            {
                Console.WriteLine(t.Category);
                foreach (var driver in t.Drivers)
                    Console.WriteLine(driver.Name.PadLeft(15));
            }
            Console.ReadKey(true);
        }
    }
