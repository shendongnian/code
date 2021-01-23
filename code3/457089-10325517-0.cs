    public class ConfigFile : IDisposable
    {
        internal XElement self;
        string file = "path to a file";
        public ConfigFile()
        {
            if(File.Exists(file))
                self = XElement.Load(file);
            else
                self = new XElement("Config");
        }
        public void Dispose() { self.Save(file); }
        public static ConfigFile Read { get { return new ConfigFile(); } }
       
        public static void Write(Action<ConfigFile> action)
        {
            using(ConfigFile file = new ConfigFile())
                action(file);
        }
    
        public Global Global
        { get { return _Global ?? (_Global = new Global(self.GetElement("Global"))); } }
        Global _Global;
    
        public Servers Servers
        { get { return _Servers ?? (_Servers = new Servers(self.GetElement("Servers"))); } }
        Servers _Servers
    
        public class Global
        {
            internal XElement self;
            public Global(XElement self) { this.self = self; }
    
            public DirectoryInfo OutputFolder
            {
                get { return self.Get<DirectoryInfo>("OutputFolder", null); }
                set { self.Set("OutputFolder", value, false); }
            }
        }
    
        public class Servers
        {
            internal XElement self;
            public Servers(XElement self) { this.self = self; }
    
            public void Add(Server server)
            {
                self.Add(server.self);
            }
    
            public string Category
            {
                get { return self.Get("category", string.Empty); }
                set { self.Set("category", value, true); }
            }
    
            public Server[] Items
            { get { return self.GetEnumerable("Server", x => new Server(x)).ToArray(); } }
    
            public class Server
            {
                internal XElement self;
                public Server(XElement self) { this.self = self; }
    
                public bool Active
                {
                    get { return self.Get("Active", false); }
                    set { self.Set("Active", value, true); }
                }
            }
        }
    }
