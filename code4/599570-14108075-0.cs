    class Program
    {
        static void Main(String[] args)
        {
            Root temp = new Root();
            temp.sensorList = new List<Sensor>();
            temp.sensorList.Add(new Sensor() { Channel = "1"});
            temp.sensorList.Add(new Sensor() { Channel = "2" });
            XmlSerializer ser = new XmlSerializer(typeof(Root));
            XDocument mydoc = new XDocument();
            using (XmlWriter writer = mydoc.CreateWriter())
            {
                ser.Serialize(writer, temp);
            }
            Console.WriteLine(" After serialize :" + mydoc.ToString());
            using (XmlReader reader = mydoc.CreateReader())
            {
                Root newTemp = (Root)ser.Deserialize(reader);
                Console.WriteLine("After deserialize :" + newTemp.sensorList.Count);
            }
        }
    }
    public class Root
    {
        [XmlElement(ElementName="Sensor")]
        public List<Sensor> sensorList
        {
            get;
            set;
        }
    }
    
    public class Sensor
    {
        public string Channel;
    }
