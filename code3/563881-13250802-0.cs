    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    
    namespace SOQuestion
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                var result = new Deserialised().getObject<Result>();
    
                var result2 = new Deserialised().getObject<Result2>();
    
                Console.WriteLine(result.status);
                Console.WriteLine(result.errorMessage);
                Console.ReadLine();
    
    
            }
        }
    
        class Deserialised
        {
    
            public T getObject<T>() where T : IResult
            {
                try
                {
                    var instance = Activator.CreateInstance<T>();
                    var mySerializer = new XmlSerializer(instance.GetType());
                    var myStream = new MemoryStream();
                    doc().Save(myStream);
                    myStream.Position = 0;
                    var r = mySerializer.Deserialize(myStream);
                    throw new DivideByZeroException();
                    return (T)r;
                }
    
                catch (Exception exp)
                {
                    var instance = Activator.CreateInstance<T>();
                    instance.errorMessage = "something wrong here";
                    return instance;
                }
                ;
            }
    
        public static XmlDocument doc()
            {
                var doc = new XmlDocument();
                var el = (XmlElement)doc.AppendChild(doc.CreateElement("Result"));
                el.SetAttribute("status", "ok");
                el.SetAttribute("status2", "notok");
                return doc;
    
            }
    
        }
    
        interface IResult
        {
            string status { get; set; }
            string errorMessage { get; set; }
        }
    
        [Serializable]
        public class Result : IResult
        {
            [XmlAttribute]
            public string status { get; set; }
    
            [XmlAttribute]
            public string errorMessage { get; set; }
    
            [XmlAttribute]
            public string message { get; set; }
        }
    
        [Serializable]
        public class Result2 : IResult
        {
            [XmlAttribute]
            public string status { get; set; }
    
            [XmlAttribute]
            public string message2 { get; set; }
    
            [XmlAttribute]
            public string errorMessage { get; set; }
        }
    
        [Serializable]
        public class Result3
        {
            [XmlAttribute]
            public string status { get; set; }
    
            [XmlAttribute]
            public string message2 { get; set; }
    
            [XmlAttribute]
            public string errorMessage { get; set; }
        }
    }
