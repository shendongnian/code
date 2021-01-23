    public class MyType
    {
        [XmlArray("Items")]
        [XmlArrayItem("ItemSum", typeof(ItemSum))]
        [XmlArrayItem("Item", typeof(SimpleItem))]
        public CItems Items { get; set; }
        public class CItems : List<Item> {}
        public class ItemSum : Item {}
        public class SimpleItem : Item {}
        public class Item
        {
            public int Value { get; set; }
        }
    }
