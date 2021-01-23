    public class MainRequest
    {
        [XmlElementAttribute("Parameters")]
        public Request Parameters { get; set; }
    }
    
    public class Request
    {
        [XmlElementAttribute(IsNullable = true)]
        public RequestSize RequestSize { get; set; }
        [XmlElement("BatchEntry")]
        public Batch[] Batches { get; set; }
    }
    public class RequestSize
    {
        [XmlAttributeAttribute]
        public string Count { get; set; }
        [XmlTextAttribute]
        public string Value { get; set; }
    }
    public class Batch
    {
        [XmlElementAttribute("ParameterEntry")]
        public Field[] Fields { get; set; }
    }
    public class Field
    {
        [XmlAttributeAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlTextAttribute]
        public string Value { get; set; }
    }
    
    public static void Main(string[] args)
    {
        var request = new MainRequest
        {
            Parameters = new Request
            {
                RequestSize = new RequestSize
                {
                    Count = "1",
                    Value = "2",
                },
                Batches = new Batch[]
                {
                    new Batch 
                    { 
                        Fields = new Field[] 
                        { 
                            new Field { Name = "AAA", Value = "111"},
                            new Field { Name = "BBB", Value = "222"},
                            new Field { Name = "CCC", Value = "333"},
                        }
                    }
                }
            }
        };
        
        using (var stream = new MemoryStream())
        using (var reader = new StreamReader(stream))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(MainRequest));
            serializer.Serialize(stream, request);
            stream.Seek(0, SeekOrigin.Begin);
            var str = reader.ReadToEnd();
        }
    }
