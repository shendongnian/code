    public class MyData
    {
        private Dictionary<string, ulong> _prop1=new Dictionary<string, ulong>(8);
        public Dictionary<string, ulong> Prop1
        {
            get { return _prop1; }
            set { _prop1 = value; }
        }
        public string CityName { get; set; }
        public ulong? Population { get; set; }
    }
