    public class Item
    {
        public int Id { get; set; }
    }
    
    class ItemComparer : IEqualityComparer<Item>
    {
        public bool Equals(Item x, Item y)
        {    
            if (Object.ReferenceEquals(x, y)) return true;
    
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                return false;
    
            return x.Id == y.Id;
        }
    
        public int GetHashCode(Item value)
        {
            if (Object.ReferenceEquals(value, null)) return 0;
    
            int hash = value.Id.GetHashCode();
    
            return hash;
        }
    
    }
