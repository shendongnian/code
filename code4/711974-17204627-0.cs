    public abstract class BaseClass
    {
        
        private string _ConfigPath;
        public string ConfigPath
        {
            get { return _ConfigPath; }
            set { _ConfigPath = value; }
        }
       
        private XDocument _Document = null;
        private XDocument document
        {
            get
            {
                if (_Document == null)
                    _Document = XDocument.Load(ConfigPath);
                return _Document;
            }
        }
        public string Version
        {
            get
            {
                return document.Root
                         .Element("InfoConfigFile")
                         .Attribute("version").Value;
            }
        }
        public IDictionary<string, string> Files
        {
            get
            {
                return document.Root
                         .Element("files")
                         .Elements("file")
                         .ToDictionary(x => x.Attribute("name").Value,
                                       x => x.Attribute("version").Value);
            }
        }
    }
