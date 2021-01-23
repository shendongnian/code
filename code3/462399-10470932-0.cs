    public class Settings
    {
        private XmlDocument _xmlDoc;
        private XmlNode _settingsNode;
        private string _path;
        public Settings(string path)
        {
            _path = path;
            LoadConfig(path);
        }
        private void LoadConfig(string path)
        {
           //TODO: add error handling
            _xmlDoc = null;
            _xmlDoc = new XmlDocument();
            _xmlDoc.Load(path);
            _settingsNode = _xmlDoc.SelectSingleNode("//appSettings");
        }
        //
        //use the same structure as in .config appSettings sections
        //
        public string this[string s]
        {
            get
            {
                XmlNode n = _settingsNode.SelectSingleNode(String.Format("//add[@key='{0}']", s));
                return n != null ? n.Attributes["value"].Value : null;
            }
            set
            {
                XmlNode n = _settingsNode.SelectSingleNode(String.Format("//add[@key='{0}']", s));
                //create the node if it doesn't exist
                if (n == null)
                {
                    n=_xmlDoc.CreateElement("add");
                    _settingsNode.AppendChild(n);
                    XmlAttribute attr =_xmlDoc.CreateAttribute("key");
                    attr.Value = s;
                    n.Attributes.Append(attr);
                    attr = _xmlDoc.CreateAttribute("value");
                    n.Attributes.Append(attr);
                }
                n.Attributes["value"].Value = value;
                _xmlDoc.Save(_path);
            }
        }
    }
