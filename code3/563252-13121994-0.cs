    [TestFixture]
    public class BilldrTest
    {
        [Test]
        public void SerializeDeserializeTest()
        {
            var foo = new Foo();
            foo.Bars.Add(new Bar { Id = 1 });
            foo.Bars.Add(new Bar { Id = 2 });
            var xmlSerializer = new XmlSerializer(typeof (Foo));
            var stringBuilder = new StringBuilder();
            using (var stringWriter = new StringWriter(stringBuilder))
            {
                xmlSerializer.Serialize(stringWriter, foo);
            }
            string s = stringBuilder.ToString();
            Foo deserialized;
            using (var stringReader = new StringReader(s))
            {
                deserialized = (Foo) xmlSerializer.Deserialize(stringReader);
            }
            Assert.AreEqual(2,deserialized.Bars.Count);
        }
    }
    
    [XmlRoot("Foo")]
    public class Foo
    {
        public Foo()
        {
            Bars= new List<Bar>();
        }
        [XmlArray("BarResponses")]
        [XmlArrayItem(typeof(Bar))]
        public List<Bar> Bars { get; set; }
        //some other elements go here.
    }
    
    [XmlRoot("Bar"),XmlType]
    public class Bar
    {
        [XmlAttribute("id")]
        public Int32 Id { get; set; }
        //some other elements go here.
    }
