    public class MyDesrializedClass
    {
        //put some properties here...
    }
    class Program
    {
        static void Main(string[] args)
        {
            SerializationServices.OnDeserializedEvent += SerializationServices_OnDeserializedEvent;
            SerializationServices.OnDeserializedFailedEvent += SerializationServices_OnDeserializedFailedEvent;
            string someXml = string.Empty; //replace this with something...
            MyDesrializedClass deserializedClass = someXml.Deserialize<MyDesrializedClass>();
        }
        private static void SerializationServices_OnDeserializedFailedEvent(string xmlSource)
        {
            //will get here before 'deserializedClass' will get it's results
        }
        private static void SerializationServices_OnDeserializedEvent(object itemDeserialized, string xmlSource)
        {
            //will get here before 'deserializedClass' will get it's results
        }
    }
