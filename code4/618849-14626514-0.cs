    [Serializable]
    public class Option
    {
        [XmlAttribute("key")]
        public EOptions Key;
        [XmlAttribute("regex")]
        public string RegEx;
    
        public override string ToString()
        {
            return Key.ToString();
        }
    }
