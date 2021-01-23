    public void Test()
    {
       var dbConfig = new DataBaseConfiguration();
       dbConfig.dbIP = "127.0.0.1";
       dbConfig.port = 12345;
       dbConfig.username = "harlam357";
       dbConfig.password = "password";
       var merlinConfig = new MerlinConfiguration();
       merlinConfig.MerlinIP = "192.168.0.1";
       merlinConfig.MerlinPort = 8080;
       merlinConfig.RecievingPort = 8081;
       var config = new AllConfig { databaseConfiguration = dbConfig, merlinConfiguration = merlinConfig };
       string xml = Serialize(config);
       var config2 = Deserialize<AllConfig>(xml);
       Debug.Assert(config2.databaseConfiguration.dbIP == "127.0.0.1");
       Debug.Assert(config2.databaseConfiguration.port == 12345);
       Debug.Assert(config2.databaseConfiguration.username == "harlam357");
       Debug.Assert(config2.databaseConfiguration.password == "password");
       Debug.Assert(config2.merlinConfiguration.MerlinIP == "192.168.0.1");
       Debug.Assert(config2.merlinConfiguration.MerlinPort == 8080);
       Debug.Assert(config2.merlinConfiguration.RecievingPort == 8081);
    }
    public static string Serialize<T>(T value) where T : class
    {
       if (value == null) return null; // throw or whatever fits your use case
       var xmlSerializer = new XmlSerializer(typeof(T));
       using (var stream = new MemoryStream())
       {
          xmlSerializer.Serialize(stream, value);
          return Encoding.UTF8.GetString(stream.GetBuffer());
       }
    }
    public static T Deserialize<T>(string xml) where T : class
    {
       if (xml == null) return null; // throw or whatever fits your use case
       var xmlSerializer = new XmlSerializer(typeof(T));
       using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
       {
          return (T)xmlSerializer.Deserialize(stream);
       }
    }
