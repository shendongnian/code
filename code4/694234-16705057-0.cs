    // The base class
    public abstract class Item : IComparable<Item> {
        public enum Category { Hats, Shirts, ... }
        public Category category;
    
        public virtual int CompareTo (Item that) {
           // default implementation
        }
    }
    
    // One of several classes extending Item
    public class Hat : Item {
        public override int CompareTo (Item that) {
           // override for Hats - can Hats be compared to other Items?
        }
    }
