    public class Item
    {
        public List<Item> ItemCollection { get; set; }
        public string Index
        {
            get
            {
                return ItemCollection.IndexOf(this).ToString();
            }
        }
        public string Name { get; set; }
    }
