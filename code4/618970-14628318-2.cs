    public class MyListComparer : IEqualityComparer<List<string>>
    {
        public bool Equals(List<string> x, List<string> y)
        {
            return x.SequenceEqual(y);  // Use this if { "a", "b" } != { "a", "b" }
            //return x.Count == y.Count && x.Count == x.Intersect(y).Count();  // Use this if { "a", "b" } == { "a", "b" }
        }
        public int GetHashCode(List<string> obj)
        {
            // GetHashCode is used to make the comparison faster by not comparing two elements that does not have the same hash code.
            // GetHashCode must satisfy the following condition
            //  (x == y) implies (GetHashCode(x) == GetHashCode(y))
            // If your are extremely lazy, you can always return 0 but then the complexity of Union will be quadratic instead of linear.
            return obj.Sum(item => item.GetHashCode());
        }
    }
