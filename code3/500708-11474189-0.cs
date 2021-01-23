    public class Settings : IDisposable
    {
        XElement self;
        FileInfo file;
        public Settings(FileInfo file)
        {
            if (file.Exists)
                self = XElement.Load(file.FullName);
            else
                self = new XElement("XmlDoc");
            this.file = file;
        }
        public Setting this[string name]
        {
            get
            {
                XElement x = self.Element(name);
                if (null == x)
                    self.Add(x = new XElement(name));
                return new Setting(x, name);
            }
        }
        public void Dispose()
        {
            self.Save(file.FullName);
        }
    }
    
    public class Setting
    {
        XElement self;
        string name;
        public Setting(XElement xsetting, string name)
        {
            self = xsetting;
            this.name = name;
        }
    
        public string ExitProgramMessage
        {
            get
            {
                XElement x = self.Element("ExitProgramMessage");
                if (null == x)
                    return "Unknown"; // default value?
                return (string)x;
            }
            set
            {
                XElement x = self.Element("ExitProgramMessage");
                if (null == x)
                    self.Add(new XElement("ExitProgramMessage", value));
                else
                    self.Value = value;
            }
        }
    
        public string Name { get { return name; } }
    }
