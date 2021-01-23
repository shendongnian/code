    public class Item
    {
        public virtual string Name { get { return "Item"; } }
    }
    public class Subitem : Item
    {
        public override string Name { get { return "Subitem"; } }
    }
