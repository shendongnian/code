    public class CItems : List<Item>
    {
        [XmlIgnore]
        public ItemSum ItemSum
        {
            get { return this.OfType<ItemSum>().Single(); }
        }
        [XmlIgnore]
        public IEnumerable<SimpleItem> SimpleItems
        {
            get { return this.OfType<SimpleItem>(); }
        }
    }
