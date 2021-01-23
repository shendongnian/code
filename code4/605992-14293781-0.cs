    public class Foo
    {
        public Foo()
        {
            Properties = new ExpandoObject();
            Status = 0;
            Version = 0;
        }
        public dynamic Properties { get; set; }
        public IDictionary<string, object> CodeMap
        {
            get { return Properties; }
        }
        private int _status;
        public int Status
        {
            get { return _status; }
            set
            {
                _status = value;
                Properties.stat = _status;
            }
        }
        private int _version;
        public int Version
        {
            get { return _version; }
            set
            {
                _version = value;
                Properties.ver = _version;
            }
        }
    }
