    using System;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                var title = new Title() { Id = 3, Value = "something" };
                var serializer = new XmlSerializer(typeof(Title));
                var stream = new MemoryStream();
                serializer.Serialize(stream, title);
                stream.Flush();
                Console.Write(new string(Encoding.UTF8.GetChars(stream.GetBuffer())));
                Console.ReadLine();
            }
        }
    
        public class Title
        {
            [XmlAttribute("id")]
            public int Id { get; set; }
            [XmlText]
            public string Value { get; set; }
        }
    
    }
