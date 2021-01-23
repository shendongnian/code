    // Not tying ourselves just to weapons here...  what about food, clothes, etc..?
    public abstract class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
        // Let's have a copy constructor
        public Item(Item other)
        {
            ID = other.ID;
            Name = other.Name;
        }
        // This part is important!
        public abstract Item Clone();
    }
