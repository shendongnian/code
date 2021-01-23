    public class Pair<T, U>
    {
        [XmlAttribute("key")]
        public T key;
        [XmlAttribute("value")]
        public U value;
        [XmlAttribute("T-Type")]
        public string ttype;
        [XmlAttribute("U-Type")]
        public string utype;
        public Pair()
        {
        }
        public Pair(T t, U u)
        {
            key = t;
            value = u;
            ttype = typeof(T).ToString();
            utype = typeof(U).ToString();
        }
    }
