    class Configuration
    {
        public string connectionString { get; set; }
        public string logPath { get; set; }
        public string errorLogPath { get; set; }
        public int ProcessesNumber { get; set; }
        public int sendAtOnce { get; set; }
        public int restInterval { get; set; }
        public int stopTime { get; set; }
    }
    static void Main(string[] args)
    {
        try
        {
            XDocument doc = XDocument.Load("config.xml");
            string conftype = "product";
            var configuration = (from config in doc.Elements("configuration").Elements("environment")
                                 where config.Attribute("name").Value.ToString() == conftype
                                 select new Configuration
                                 {
                                     connectionString = config.Element("connectionString").Value.ToString(),
                                     logPath = config.Element("logPath").Value.ToString(),
                                     errorLogPath = config.Element("errorLogPath").Value.ToString(),
                                     ProcessesNumber = int.Parse(config.Element("ProcessesNumber").Value.ToString()),
                                     sendAtOnce = int.Parse(config.Element("sendAtOnce").Value.ToString()),
                                     restInterval = int.Parse(config.Element("restInterval").Value.ToString()),
                                     stopTime = int.Parse(config.Element("stopTime").Value.ToString()),
                                 }).First();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }
