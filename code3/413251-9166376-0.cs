    ....
        [XmlArray("Values")]
        [XmlArrayItem("KeyValuePair")]  //not needed if MyItem is named KeyValuePair
        public List<MyItem> Values { get; set; }
    }
    public class MyItem
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
