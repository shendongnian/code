    private static readonly object Locker = new object();
    private static XmlDocument _doc = new XmlDocument();
    static void Main(string[] args)
    {
        if (File.Exists("logs.txt"))
            _doc.Load("logs.txt");
        else
        {
            var root = _doc.CreateElement("hosts");
            _doc.AppendChild(root);
        }
        
        for (int i = 0; i < 100; i++)
        {
            new Thread(new ThreadStart(DoSomeWork)).Start();
        }
    }
    static void DoSomeWork()
    {
        /*
         * Here you will build log messages
         */
        Log("192.168.1.15", "alive");
    }
    static void Log(string hostname, string state)
    {
        lock (Locker)
        {
            var el = (XmlElement)_doc.DocumentElement.AppendChild(_doc.CreateElement("host"));
            el.SetAttribute("Hostname", hostname);
            el.AppendChild(_doc.CreateElement("State")).InnerText = state;
            _doc.Save("logs.txt");
        }
    }
