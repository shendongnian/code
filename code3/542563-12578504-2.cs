    public class Entity { }
    public class Item : Entity, IChainElement<Item>
    {
        public Item Previous { get; set; }
        public Item Next { get; set; }
    }
