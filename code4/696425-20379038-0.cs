    public class Choices
    {
        [XmlChoiceIdentifier("ItemType")]
        [XmlElement("Text", Type = typeof(string))]
        [XmlElement("Integer", Type = typeof(int))]
        [XmlElement("LongText", Type = typeof(string))]
        public object Choice { get; set; }
        [XmlIgnore]
        public ItemChoiceType ItemType;
    }
    [XmlType(IncludeInSchema = false)]
    public enum ItemChoiceType
    {
        Text,
        Integer,
        LongText
    }
    class Program
    {
        static void Main(string[] args)
        {
            Choices c1 = new Choices();
            c1.Choice = "very long text"; // You can put here a value of String or Int32.
            c1.ItemType = ItemChoiceType.LongText; // Set the value so that its type match the Choice type (Text or LongText due to type of value is string).
            var serializer = new XmlSerializer(typeof(Choices));
            using (var stream = new FileStream("Choices.xml", FileMode.Create))
                serializer.Serialize(stream, c1);
            // Produced xml file.
            // Notice:
            // 1. LongText as element name
            // 2. Choice value inside the element
            // 3. ItemType value is not stored
            /*
            <?xml version="1.0"?>
            <Choices xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
              <LongText>very long text</LongText>
            </Choices>
            */
            Choices c2;
            using (var stream = new FileStream("Choices.xml", FileMode.Open))
                c2 = (Choices)serializer.Deserialize(stream);
            // c2.ItemType is restored
        }
    }
