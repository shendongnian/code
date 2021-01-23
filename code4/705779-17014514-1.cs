    public class item
    {
        public string displayname { get; set; }
        List<atmosphere> _atmosphere = new List<atmosphere>();
        [XmlArrayItem("part")]
        public List<atmosphere> atmosphere
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
    public class atmosphere
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
