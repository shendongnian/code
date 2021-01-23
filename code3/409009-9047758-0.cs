    List<Release> releases = xmlString.Load();
--- 
    
    [XmlType("release")]
    public class Release
    {
        [XmlElement("artist")]
        public string Artist { get; set; }
        [XmlElement("albumTitle")]
        public string AlbumTitle { get; set; }
        [XmlArray("tracklist")]
        [XmlArrayItem("track")]
        public List<Track> TrackList { get; set; }
    }
        
    [XmlType("track")]
    public class Track
    {
        [XmlElement("position")]
        public string Position { get; set; }
        [XmlElement("title")]
        public string Title { get; set; }
    }
    public static class MyExtensions
    {
        public static List<Release> Load(this string xmlStr)
        {
            using (StringReader reader = new StringReader(xmlStr))
            {
                XmlSerializer xs = new XmlSerializer(typeof(List<Release>), new XmlRootAttribute("releases"));
                return (List<Release>)xs.Deserialize(reader);
            }
        }
        public static string Save(this List<Release> list)
        {
            XmlWriterSettings settings = new System.Xml.XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            settings.Indent = true;
            settings.Encoding = Encoding.UTF8;
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);
            using (StringWriter writer = new StringWriter())
            {
                XmlWriter xmlWriter = XmlWriter.Create(writer, settings);
                XmlSerializer xs = new XmlSerializer(typeof(List<Release>), new XmlRootAttribute("releases"));
                xs.Serialize(xmlWriter, list, namespaces);
                return writer.ToString();
            }
        }
    }
