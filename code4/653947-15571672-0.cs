    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    namespace xmlTest
    {
        class Program
        {
            static void Main()
            {
                XDocument doc = XDocument.Load("C:\\Users\\me\\Desktop\\so.xml");
                var personDataDetails = (from p in doc.Descendants().Elements()                                     
                                         where p.Name.LocalName == "personData"
                                             select p);
    
                foreach (var item in personDataDetails)
                {
                    Console.WriteLine(item.ToString());
                }
    
                Console.ReadKey();
            }
        }
    }
