    public class Class1 : IDisposable
        {
            private string filePath;
            private XDocument document;
    
            public Class1(string xmlFilePath)
            {
                this.filePath = xmlFilePath;
                document = XDocument.Load(xmlFilePath);
            }
    
            public XElement ExampleTag1
            {
                get
                {
                    return document.Root.Element("ExampleTag1");
                }
            }
            
            public void Dispose()
            {
                document.Save(filePath);
            }
        }
