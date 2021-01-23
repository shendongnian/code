    using System;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var response = new MoveInInfoResponse
                {
                    RentalPeriods = new SerializableDictionary<int, string> 
                    { { 1, "Period 1" }, { 2, "Period 2" } }
                };
    
                string xml = Serialize(response);
            }
    
            static string Serialize(Object obj)
            {
                var serializer = new XmlSerializer(obj.GetType());
                var settings = new XmlWriterSettings { Indent = true, OmitXmlDeclaration = true };
    
                using (var stream = new StringWriter())
                {
                    using (var writer = XmlWriter.Create(stream, settings))
                        serializer.Serialize(writer, obj);
                    return stream.ToString();
                }
            }
        }
    
        [Serializable]
        public class MoveInInfoResponse
        {
            public SerializableDictionary<int, String> RentalPeriods
            { get; set; }
        }
    }
