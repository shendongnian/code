    public class ItemsComparer : IEqualityComparer<Items>
    {
        public bool Equals(Items x, Items y)
        {
            return x.Title == y.Title;
        }
        public int GetHashCode(Items obj)
        {
            return obj.Title.GetHashCode();
        }
    }
