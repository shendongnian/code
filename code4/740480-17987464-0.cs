    [XmlRoot(ElementName = "DietPlan")]
    public class TestData
    {
        [XmlElement("Fruit")]
        public string Fruits { get; set; }
        [XmlElement("Veggie")]
        public string test { get; set; }
    }
