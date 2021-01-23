    internal class NameComparer : IEqualityComparer<Item> {
        public bool Equals(Item x, Item y) { return x.Name == y.Name;     }
        public int GetHashCode(Item obj) { return obj.Name.GetHashCode(); }
    }
    var distinctItems = MyCollection.Distinct(new NameComparer());
