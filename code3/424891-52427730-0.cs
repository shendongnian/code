    [System.SerializableAttribute()]
    public class MyObject
    {
        public int Id { get; set; }
        [XmlElement(Type = typeof(object), ElementName = "Item"), //added
            XmlElement(Type = typeof(MyItem[]), ElementName = "Item_asArrayOfMyItem")] //added
        public object Item { get; set; }    // <---- Note type *object* here
    }
