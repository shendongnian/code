    public class IndexedDictionary : KeyedCollection<List<int>, Item>
    {
        public IndexedDictionary() : base(new MyEqualityComparer())
        {
        }
        protected override List<int> GetKeyForItem(Item item)
        {
            return item.val;
        }
        public class MyEqualityComparer : IEqualityComparer<List<int>>
        {
            public bool Equals(List<int> x, List<int> y)
            {
                return x.SequenceEqual(y);
            }
            public int GetHashCode(List<int> obj)
            {
                return obj.Aggregate(0, (s, x) => s ^= x.GetHashCode());
            }
        }
    }
