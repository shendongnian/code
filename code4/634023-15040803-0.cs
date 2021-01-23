    using System.Diagnostics;
    using System.Xml;
    
    namespace XmlExample
    {
        class Program
        {
            static void Main(string[] args)
            {
                string file = @"C:\test.txt";
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.ConformanceLevel = ConformanceLevel.Fragment;
                using (XmlReader reader = XmlReader.Create(file, settings))
                {
                    while (reader.Read())
                        Debug.WriteLine("NodeType: {0} NodeName: {1}", reader.NodeType, reader.Name);
                }
            }
        }
    }
