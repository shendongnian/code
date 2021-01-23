                private static List<TestType> testType;
        
                public static List<TestType> TestTypes
                {
                    get
                    {
                        if (testType== null)
                        {
                            var fileName = GetFilePath("TestTypes.xml");
        
                            testType= DeseriaizeXml<List<TestType>>(fileName);
                        }
        
                        return testType;
                    }
                }
    
    
    
      private static T DeseriaizeXml<T>(String fileName) where T : class
                {
                    using (var stream = File.OpenRead(fileName))
                    {
                        return DeseriaizeXml<T>(stream);
                    }
                }
        
                private static T DeseriaizeXml<T>(Stream stream) where T : class
                {
                    using (
                        var xmlReader = XmlDictionaryReader.CreateTextReader(stream, Encoding.UTF8,
                                                                             new XmlDictionaryReaderQuotas(), null))
                    {
                        var xmlSer = new XmlSerializer(typeof (T));
        
                        return xmlSer.Deserialize(xmlReader) as T;
                    }
                }
