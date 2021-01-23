    public class Root
    {
        [XmlElement("Row")]
        public List<BOMItems> Row { get; set; }
    }
    public class BOMItems
    {
        [XmlElement("ITEMNO")]
        public string ITEMNO { get; set; }
        [XmlElement("USED")]
        public string USED { get; set; }
        [XmlElement("PARTSOURCE")]
        public string PARTSOURCE { get; set; }
        [XmlElement("QTY")]
        public string QTY { get; set; }
        [XmlElement("CUSTPARTNO")]
        public string CUSTPARTNO { get; set; }
        [XmlElement("CREV")]
        public string CREV { get; set; }
        [XmlElement("DESCRIPT")]
        public string DESCRIPT { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var serializer = new XmlSerializer(typeof(Root));
            var reader = XmlReader.Create(new StringReader(File.ReadAllText("c:\\tet.xml")));
            var serializedOutput = (Root)serializer.Deserialize(reader);
            Console.ReadKey();
        }
