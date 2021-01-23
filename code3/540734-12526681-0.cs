    class Fruit
    {
        public String Category { get; set; }
        public String SubCategory { get; set; }
        public class Comparer : IEqualityComparer<Fruit>
        {
            public bool Equals(Fruit x, Fruit y)
            {
                return y.Category == y.Category && x.SubCategory == y.SubCategory;
            }
            public int GetHashCode(Fruit obj)
            {
                return (obj.Category + obj.SubCategory).GetHashCode();
            }
        }
    }
