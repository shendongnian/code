    public interface ISensor { }
    [Serializable]
    public class Sensor : ISensor { }
    [Serializable]
    public class Root
    {
        // Changed List<ISensor> to List<Sensor>. I also changed
        // XmlElement to XmlArray so it would appear around the list.       
        [XmlArray("Sensor")]
        public List<Sensor> SensorList { get; set; }
    }
    [Serializable]
    public class SensorA : Sensor
    {
        [XmlElement("A")]
        public string A { get; set; }
    }
    [Serializable]
    public class SensorB : Sensor
    {
        [XmlElement("B")]
        public string B { get; set; }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            XmlSerializer xmlSerializer;
            Root root = new Root();
            root.SensorList = new List<Sensor>();
            root.SensorList.Add(new SensorA() {A = "foo"});
            root.SensorList.Add(new SensorB() {B = "bar"});
            // Tell the serializer about derived types
            xmlSerializer = new XmlSerializer(typeof (Root), 
                new Type[]{typeof (SensorA), typeof(SensorB)});
            StringBuilder stringBuilder = new StringBuilder();
            using (StringWriter stringWriter = new StringWriter(stringBuilder))
            {
                xmlSerializer.Serialize(stringWriter, root);
            }
            // Output the serialized XML
            Console.WriteLine(stringBuilder.ToString());
            Root root2;
            using (StringReader stringReader = new StringReader(stringBuilder.ToString()))
            {
                root2 = (Root) xmlSerializer.Deserialize(stringReader);
            }
        }
    }
