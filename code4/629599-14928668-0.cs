    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    
    namespace XmlReaderTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                XmlTextReader reader = new XmlTextReader("../../Portfolio.xml");
                reader.WhitespaceHandling = WhitespaceHandling.None;
                List<string> priceDataFile = new List<string>();
                while (reader.Read())
                {
                    if (reader.Name == "file")
                    {
                        priceDataFile.Add(reader.GetAttribute("name"));
                    }
                    else
                        continue;
                }
    
                reader.Close();
    
                foreach (string file in priceDataFile)
                {
                    Console.WriteLine(file);
                }
    
                Console.ReadLine();
            }
        }
    }
