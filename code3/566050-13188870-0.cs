    public class StackOverflow_13188624
    {
        const string XML = @"  <Item>
                                <Description>Timber(dry)</Description>
                                <Measure Type=""VOLUME"">
                                  <Value>1.779</Value>
                                  <Units>m3</Units>
                                </Measure>
                                <Measure Type=""WEIGHT"">
                                  <Value>925.08</Value>
                                  <Units>Kilogram</Units>
                                </Measure>
                                <Measure>
                                  <Value>1</Value>
                                  <Units>Units</Units>
                                </Measure>
                              </Item>";
        public class Item
        {
            public Item()
            {
                this.Measures = new List<Measure>();
            }
            public string Description { get; set; }
            [System.Xml.Serialization.XmlElement(ElementName = "Measure")]
            public List<Measure> Measures { get; set; }
        }
        public class Measure
        {
            public string Value { get; set; }
            public string Units { get; set; }
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Type { get; set; }
        }
        public static void Test()
        {
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(XML));
            XmlSerializer xs = new XmlSerializer(typeof(Item));
            Item item = (Item)xs.Deserialize(ms);
            Console.WriteLine(item.Measures);
        }
    }
