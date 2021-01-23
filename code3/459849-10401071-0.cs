    public class MyConfig : IDisposable
    {
        string file = "path to file";  // probably in App_Data if this is asp.net
        XElement self;
    
        public MyConfig()
        {
            if(File.Exists(file))
                self = XElement.Load(file);
            else
                self = new XElement("root");
        }
    
        public void Add(string key, string value)
        {
            if (!Items.ContainsKey(key))
            {
                self.Add(new XElement("pair",
                    new XAttribute("Key", key),
                    new XAttribute("Value", value)));
                _Items = null;
            }
        }
    
        public void Dispose()
        {
            self.Save(file);
        }
    
        public static Dictionary<string, string> Items
        {
            get
            {
                if (null == _Items)
                {
                    _Items = Read.self.Elements().ToDictionary(
                        x => x.Attribute("Key").Value,
                        x => x.Attribute("Value").Value);
                }
                return _Items;
            }
        }
        static Dictionary<string, string> _Items;
    
        public static MyConfig Read { get { return new MyConfig(); } }
        public static void Write(Action<MyConfig> action)
        {
            using (MyConfig config = new MyConfig())
                action(config);
        }
    }
