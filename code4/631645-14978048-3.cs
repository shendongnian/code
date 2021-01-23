    class Item : IEqualityComparer<Item>
    {
        public int ID;
        public string Name;
        public int Amount;
        public bool Equals(Item x, Item y)
        {
            if (x == null || y == null) return false;
            bool equals = x.ID == y.ID && x.Name == y.Name;
            return equals;
        }
        public int GetHashCode(Item obj)
        {
            if (obj == null) return int.MinValue;
            int hash = 19;
            hash = hash + obj.ID.GetHashCode();
            hash = hash + obj.Name.GetHashCode();
            return hash;
        }
    }
