    public class BaseEntity<T> where T: class
    {
        public List<T> List { set; get; }
        public BaseEntity(IEnumerable<T> list)
        {
            this.List = new List<T>();
            foreach (T k in list)
            {
                this.List.Add(k);
            }
        }
    }
    public class KeyValuePair
    {
        public string key;
        public string value;
        public string meta;
    }
    public class KeyValuePairList : BaseEntity<KeyValuePair>
    {
        public KeyValuePairList(IEnumerable<KeyValuePair> list) 
            : base(list) { }
    }
