    [JsonObject(IsReference = true)] 
    public class Cart
    {
        public List<Item> Items = new List<Item>();
    }
    public class Item
    {
        public Cart Cart;
    }
