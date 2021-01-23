    public class item
    {
        public string displayname { get; set; }
        List<part> _atmosphere = new List<part>();
        public List<part> atmosphere
        {
            get
            {
                return _atmosphere;
            }
            set
            {
                _atmosphere = value;
            }
        }
    }
    public class part
    {
        [XmlAttribute]
        public string type { get; set; }
        string _data;
        [XmlText]
        public string Data
        {
            get { return _data; }
            set { _data = value; }
        }
    }
