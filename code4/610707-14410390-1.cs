    public class MyConfig
    {
        const string configPath = @"...";
        public string Setting1 { get; set; }
        // ...
        public static MyConfig Load()
        {
            var serializer = new XmlSerializer(typeof(MyConfig));
            using (var reader = new StreamReader(configPath))
                return (MyConfig)serializer.Deserialize(reader);
        }
        public void Save()
        {
            var serializer = new XmlSerializer(typeof(MyConfig));
            using (var writer = new StreamWriter(configPath))
                serializer.Serialize(writer, this);
        }
    }
