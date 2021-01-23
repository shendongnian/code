    public class Item
    {
        public virtual string Name {get; protected set;}
    }
    public class Subitem : Item
    {
        public override string Name {get; protected set;}
    }
