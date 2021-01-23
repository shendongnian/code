    class ListType
    {
        public DateTime val { get; set; }
        public class DateComparer : IEqualityComparer<ListType>
        {
            public bool Equals(ListType x, ListType y)
            {
                if (ReferenceEquals(x, y))
                    return true;
                else if (x == null || y == null)
                    return false;
                return x.val.Date == y.val.Date;
            }
            public int GetHashCode(ListType obj)
            {
                return obj.val.Date.GetHashCode();
            }
        }
    }
