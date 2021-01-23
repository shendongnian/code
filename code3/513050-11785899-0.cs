     class Program
    {
        static void Main(string[] args)
        {
            Links ls = new Links();
            ls.Link.Add(new Link() { Name = "Mike", Url = "www.xml.com" });
            ls.Link.Add(new Link() { Name = "Jim", Url = "www.xml.com" });
            ls.Link.Add(new Link() { Name = "Peter", Url = "www.xml.com" });
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Links));
            StringWriter stringWriter = new StringWriter();
            xmlSerializer.Serialize(stringWriter, ls);
            string serializedXML = stringWriter.ToString();
            Console.WriteLine(serializedXML);
            Console.ReadLine();
        }
    }
    [XmlRoot("Links")]
    public class Links
    {
        public Links()
        {
            Link = new List<Link>();
        }
        [XmlElement]
        public List<Link> Link { get; set; }
    }
    [XmlType("Link")]
    public class Link
    {
        [XmlAttribute("Name")]
        public string Name { get; set; }
        [XmlAttribute("Href")]
        public string Url { get; set; }
    }
