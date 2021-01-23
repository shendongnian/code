    namespace XmlReading
    {
        class Program
        {
            static void Main(string[] args)
            {
                //Create an instance of the XmlTextReader and call Read method to read the file            
                XmlTextReader textReader = new XmlTextReader("D:\\myxml.xml");
                textReader.Read();
                
                string brandname = null;
    
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(textReader);
    
                XmlNodeList BCode = xmlDoc.GetElementsByTagName("Brandcode");
                XmlNodeList BName = xmlDoc.GetElementsByTagName("Brandname");
                for (int i = 0; i < BCode.Count; i++)
                {
                    if (BCode[i].InnerText == "001")
                    {
                        brandname = BName[i].InnerText;                    
                    }
                }
                Console.WriteLine(brandname);
                Console.ReadLine();
            }
        }
    }
