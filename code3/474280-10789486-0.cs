    var serializer = new XmlSerializer(typeof(Hosts));
    var hosts = (Hosts)serializer.Deserialize(new StringReader(str));
...
    [XmlRoot("HOSTS")]
    public class Hosts : List<Host> {}
    public class Host {
        [XmlAttribute("id")]
        public int Id { get; set; }
        public string Extension { get; set; }
        public string FolderPath { get; set; }
    }
