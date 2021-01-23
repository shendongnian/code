    public class DynamicComparer : IEqualityComparer<object>
    {
        public bool Equals(dynamic x, dynamic y)
        {
            return x.Name == y.Name && x.Age == y.Age;
        }
        public int GetHashCode(dynamic obj)
        {
            return ((string)obj.Name).GetHashCode() * 31
                + ((int)obj.Age).GetHashCode();
        }
    }
