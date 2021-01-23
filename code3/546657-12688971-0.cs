    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    
    namespace Stackoverflow
    {
        public class Foo
        {
            public int Id { get; set; }
            public Bar Bar { get; set; }
        }
    
        public class Bar { }
    
        class Program
        {
            private static void Main()
            {
                var foos = new List<Foo>
                               {
                                   new Foo { Id =1, Bar = new Bar()},
                                   new Foo { Id =2, Bar = null},
                                   new Foo { Id =3, Bar = new Bar()},
                                   new Foo { Id =4, Bar = null},
                               };
    
                var xml = ToXml(foos);
    
                var result = GetData<List<Foo>>(xml);
            }
    
            private static string ToXml(List<Foo> foos)
            {
                XmlSerializer ser = new XmlSerializer(foos.GetType());
                StringBuilder sb = new StringBuilder();
                StringWriter writer = new StringWriter(sb);
                ser.Serialize(writer, foos);
    
                string xml = sb.ToString();
                return xml;
            }
    
            public static T GetData<T>(string xml)
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);
                
                XmlNodeReader reader = new XmlNodeReader(doc.DocumentElement);
                XmlSerializer ser = new XmlSerializer(typeof(T));
                object obj = ser.Deserialize(reader);
    
                T result = (T)obj;
    
                return result;
            }
        }
    }
