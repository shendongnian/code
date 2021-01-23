    private void button1_Click(object sender, EventArgs e)
    {
        //Serialize
        //var x = File.ReadAllText(@"C:\TableInfo.xml");
        //var stringReader = new StringReader(x);
        //var deserializer = new XmlSerializer(typeof(Table));
        //var myTable = (Table)deserializer.Deserialize(stringReader);
        //Deserialize
        var myTable2 = new Table();
        myTable2.Row = new Row[1];
        myTable2.Row[0] = new Row();
        myTable2.Row[0].id = "myId";
        myTable2.Row[0].Heading = "myHeading";
        myTable2.Row[0].Items = new Items();
        myTable2.Row[0].Items.Item = new Item[1];
        myTable2.Row[0].Items.Item[0] = new Item();
        myTable2.Row[0].Items.Item[0].BodyText = new BodyText() { color = "Red" };
        myTable2.Row[0].Items.Item[0].BodyText.Value = "135";
        myTable2.Row[0].Items.Item[0].car = "myCar";
        myTable2.Row[0].Items.Item[0].id = "myId";
        myTable2.Row[0].Items.Item[0].Subscript = new Subscript[1];
        myTable2.Row[0].Items.Item[0].Subscript[0] = new Subscript();
        myTable2.Row[0].Items.Item[0].Subscript[0].Value = "3";
        XmlSerializer serializer = new XmlSerializer(typeof(Table));
        TextWriter textWriter = new StreamWriter(@"C:\TableInfo.xml");
        serializer.Serialize(textWriter, myTable2);
        textWriter.Close();
    }
    [XmlRoot("Table")]
    public partial class Table
    {
        [XmlElement("Row")]
        public Row[] Row { get; set; }
    }
    [XmlRoot("Row")]
    public partial class Row
    {
        [XmlElement("Heading")]
        public string Heading { get; set; }
        [XmlElement("Items")]
        public Items Items { get; set; }
        [XmlElement("BodyText")]
        public BodyText BodyText { get; set; }
        [XmlAttribute("id")]
        public string id { get; set; }
    }
    [XmlRoot("Items")]
    public partial class Items
    {
        [XmlElement("Item")]
        public Item[] Item { get; set; }
    }
    [XmlRoot("Item")]
    public partial class Item
    {
        [XmlElement("BodyText")]
        public BodyText BodyText { get; set; }
        [XmlElement("PhoneNumber")]
        public PhoneNr[] PhoneNr { get; set; }
        [XmlElement("Subscript")]
        public Subscript[] Subscript { get; set; }
        [XmlAttribute("car")]
        public string car { get; set; }
        [XmlAttribute("id")]
        public string id { get; set; }
    }
    [XmlRoot("BodyText")]
    public partial class BodyText
    {
        [XmlAttribute("color")]
        public string color { get; set; }
        [XmlAttribute("fonttype")]
        public string fonttype { get; set; }
        [XmlAttribute("fontsize")]
        public string fontsize { get; set; }
        [XmlAttribute("fontweight")]
        public string fontweight { get; set; }
        [XmlText]
        public string Value { get; set; }
    }
    [XmlRoot("Subscript")]
    public partial class Subscript
    {
        [XmlAttribute("for")]
        public string @for { get; set; }
        [XmlText]
        public string Value { get; set; }
    }
    [XmlRoot("PhoneNr")]
    public partial class PhoneNr
    {
        [XmlElement("Display")]
        public string Display { get; set; }
        [XmlElement("Number")]
        public string Number { get; set; }
        [XmlAttribute("id")]
        public string id { get; set; }
    }
