    public class Category
    {
        private readonly IList<Item> _items;
        public Category()
        {
            _items = new List<Item>();
        }
        public int id { get; set; }
        public string Name { get; set; }
        public IList<Item> Items { get { return _items; } }
    }
    public class Item
    {
        public int id { get; set; }
        public string Name { get; set; }
    }
