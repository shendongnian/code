    public class MyClass
    {
        [JsonProperty("for-sale")]
        public IList<Item> forSale { get; set; }
        public IList<Item> vehicles { get; set; }
        public IList<Item> rentals { get; set; }
    }
    public class Item
    {
        public string name { get; set; }
        public string type { get; set; }
    }
