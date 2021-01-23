     public class Program
    {
        static void Main(string[] args)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(ServerConnections));
            var reader = new StreamReader(@"../../Test.xml");
            var entries = (ServerConnections)deserializer.Deserialize(reader);
            reader.Close();
        }
        public class ServerConnections
        {
            public ServerConnectionEntry[] Entries { get; set; }
        }
        public class ServerConnectionEntry
        {
            public string Name { get; set; }
            public string Host { get; set; }
            public string Port { get; set; }
            public string Username { get; set; }
            public BinaryCode AuthHash { get; set; }
        }
        public class BinaryCode
        {
            [XmlElement("base64Binary")]
            public string Code { get; set; }
        }
    }
