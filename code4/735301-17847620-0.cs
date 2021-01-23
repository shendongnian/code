using System.IO;
using System.IO.IsolatedStorage;
using System.Xml.Serialization;
namespace Runner
{
    public static class SerializationHelper
    {
        public static void Save(Schedule shedule)
        {
            using (var store = IsolatedStorageFile.GetUserStoreForApplication())
            using (var fileStream = store.CreateFile("Schedule.xml"))
            using (var writer = new StreamWriter(fileStream))
            {
                var ser = new XmlSerializer(typeof(Schedule));
                ser.Serialize(writer, shedule);
                writer.Close();
            }
        }
        public static Schedule Load()
        {
            var shcedule = new Schedule();
            using (var storage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (storage.FileExists("Schedule.xml"))
                {
                    using (var stream = storage.OpenFile("Schedule.xml", FileMode.Open))
                    {
                        var xml = new XmlSerializer(typeof(Schedule));
                        shcedule = xml.Deserialize(stream) as Schedule;
                        stream.Close();
                    }
                }
            }
            return shcedule;
        }
    }
}
