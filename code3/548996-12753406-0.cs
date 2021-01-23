    using System.IO;
    using System.Xml.Serialization;
    namespace Playground
    {
        public class Program
        {
            [XmlRoot("settings")]
            public class Settings
            {
                [XmlElement("site")]
                public Site[] Sites;
            }
            public class Site
            {
                [XmlElement("name")]
                public string Name;
                [XmlElement("prefix")]
                public string Prefix;
                [XmlArrayItem("tag", typeof(Tag))]
                [XmlArray("tags")]
                public Tag[] Tags;
            }
        
            public class Tag
            {
                [XmlAttribute("column")]
                public string Column;
                [XmlText]
                public string Name;
            }
            public static void Main(string[] args)
            {
                using (FileStream reader = new FileStream("mydoc.xml", FileMode.Open))
                {
                    XmlSerializer ser = new XmlSerializer(typeof (Settings));
                    Settings o = ser.Deserialize(reader) as Settings;
                }
            }
        }
    }
