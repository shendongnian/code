    public class Item {
        public string ItemNumber { get; set; }
        public string Description { get; set; }
        public string Quantity { get; set; }
        public override bool Equals(Object o) {
            // Implement your Equals here
        }
        public override int GetHashCode() {
            // Implement your hash code method here
        }
    }
    public class ItemCollection : Dictionary<string, Item> {
        public override bool Equals(Object o) {
            // Implement your collection's Equals method here
        }
    }
