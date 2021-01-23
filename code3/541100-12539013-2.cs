    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.XPath;
    using System.IO;
    using System;
    
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var fs = new StreamReader("./test.xml"))
            {
                var doc = XDocument.Load(fs);
    
                var parms = doc.Root.XPathSelectElements("params/tp")
                    .ToDictionary(el => el.Attribute("name").Value, el => el.Value);
    
                var nits = doc.Root.XPathSelectElements("nits/tn")
                    .Select(el => new {
                            Name = el.Attribute("name").Value,
                            Min  = el.Element("min").Value,
                            Max  = el.Element("max").Value
                        }).ToList();
    
                foreach (var kvp in parms)
                    Console.WriteLine("{0}: {1}", kvp.Key, kvp.Value);
    
                foreach (var nit in nits
                        .OrderBy(nit => nit.Name)
                        .ThenBy(nit => nit.Max))
                {
                    Console.WriteLine("{0}: {1} {2}", nit.Name, nit.Min, nit.Max);
                }
            }
        }
    }
