    public class Model
	{
        IEnumerable<Order> Orders { get; set; }
    }
    public class Order
    {
        public int OrderId { get; set; }
        IEnumerable<Item> Items { get; set; }
    }
    public class Item
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
    }
