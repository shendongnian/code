    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    namespace TestLinqXml
    {
        public class Program
        {
            private static void Main(string[] args)
            {
                // load original doc
                var doc = XDocument.Load(@"C:\TestCode\TestLinqXml\TestLinqXml\XML\Orders.xml");
    
                // query it with Linq using lambda patterns.
                var list = doc.Descendants("Person")
                              .Select(x => new 
                                      // expand descendents out into a class I make up below by declarining new and defining object
                                      {
                                          Name = x.Attribute("Name").Value,
                                          OrderCount = x.Descendants("Order").Count()
                                      }
                    );
    
                // recreate the new doc
                XDocument newdoc = new XDocument(
                    new XDeclaration("1.0", "UTF-8", "yes"),
                    new XElement("person",
                                 list.Select(n =>
                                             new XElement(n.Name,
                                                          new XAttribute("OrderCount", n.OrderCount)
                                                 ))
                        )
                    );
    
                // save it
                newdoc.Save(@"C:\TestCode\TestLinqXml\TestLinqXml\XML\output.xml");
            }
        }
    }
