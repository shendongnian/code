    namespace XmlReading
    {
        class Program
        {
            static void Main(string[] args)
            {
                //Create an instance of the XmlTextReader and call Read method to read the file            
                XmlTextReader textReader = new XmlTextReader("C:\\myxml.xml");
                textReader.Read();
    
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(textReader);
    
                XmlNodeList BCode = xmlDoc.GetElementsByTagName("Brandcode");
                XmlNodeList BName = xmlDoc.GetElementsByTagName("Brandname");
                for (int i = 0; i < BCode.Count; i++)
                {
                    if (BCode[i].InnerText == "001")
                        Console.WriteLine(BName[i].InnerText);                
                }
    
                Console.ReadLine();
            }
        }
    }
