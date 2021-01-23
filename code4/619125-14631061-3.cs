    public class ObjectArrayComparer : IEqualityComparer<object[]>
    {
        // Determines whether x and y are equal or not
        public bool Equals(object[] x, object[] y)
        {
            return object.ReferenceEquals(x, y) // Returns true if they are the same array instance
                || (x != null && y != null && x.SequenceEqual(y));  // Returns true if x and y are not null and have the same elements (order dependent)
        }
        // Function that allow to fastly determine if an element is in a set of not.        
        // This function must have the following property:
        //   x.Equals(y) implies GetHashCode(x) == GetHashCode(y)
        public int GetHashCode(object[] obj)
        {
            if (obj == null)
                return 0;
            // Unchecked sum of the Hash Codes of all elements in obj
            return unchecked(obj.Select(o => o != null ? o.GetHashCode() : 0).Aggregate(0, (a, b) => a + b));
        }
    }
