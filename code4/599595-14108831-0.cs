    public interface ISensor { }
    
    [Serializable]
    public class Sensor : ISensor { }
    
    [Serializable]
    public class Root
    {
        // Changed from List<ISensor> to List<Sensor>
        [XmlElement("SensorList")]
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
    
            // Tell the serializer the types that can override Sensor
            xmlSerializer = new XmlSerializer(typeof (Root),
                new Type[]{typeof (SensorA), typeof(SensorB)});
            using (MemoryStream memoryStream = new MemoryStream())
            {
                xmlSerializer.Serialize(memoryStream, root);
            }
        }
    }
