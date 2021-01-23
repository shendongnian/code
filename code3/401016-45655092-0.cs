    public class Item
    {
        public virtual string Name { get; set; } = "Item";
    }
    public class Subitem : Item
    {
        public override string Name { get; set; } = "Subitem";
    }
