    public class Item
    {
        public virtual string Name
        {
            get { return "Item"; }
        }
    }
    
    public class SubItem : Item
    {
        public override string Name
        {
            get { return "Subitem"; }
        }
    }
