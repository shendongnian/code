    public class MyData
    {
        private Dictionary<string, ulong> _prop1=new Dictionary<string, ulong>();
        private object[] _prop2= new object[8];
        public Dictionary<string, ulong> Prop1
        {
            get { return _prop1; }
            set { _prop1 = value; }
        }
        public object[] Prop2
        {
            get { return _prop2; }
            set { _prop2 = value; }
        }
        public string PrimaryKey { get; set; }
        public ulong? Prop3 { get; set; }
    }
