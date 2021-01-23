    public class ItemEqualityComparer : IEqualityComparer<Item>
    {
        private ItemEqualityComparer()
        {
        }
    
        public static IEqualityComparer<Item> Instance
        {
            get
            {
                return new ItemEqualityComparer();
            }
        }
    
        public bool Equals(Item x, Item y)
        {
            return
                x.support == y.support &&
                x.val.SequenceEqual(y.val);
        }
    
        public int GetHashCode(Item obj)
        {
            int hash = 27;
            hash += (13 * hash) + obj.support.GetHashCode();
            foreach (var item in obj.val)
            {
                hash += (13 * hash) + item.GetHashCode();
            }
            return hash;
        }
    }
