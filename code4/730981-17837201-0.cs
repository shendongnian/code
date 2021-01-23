    public class Item
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public CommercialValue CommercialValue { get; set; }
        // other properties
    }
    
    public class CommercialValue
    {
        public Item Item { get; set; }
        public decimal Value { get; set; }
        // other properties
    }
