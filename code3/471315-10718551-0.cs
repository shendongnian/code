    public class Item
    {
        public Guid Id { get; set; }
        public Guid ThreadId { get; set; }
        public ICollection<Item> ChildItems { get; set; }
        /* Other properties */
    }
