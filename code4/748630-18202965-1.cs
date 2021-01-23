    public class CustomComparer : IEqualityComparer<List<string>>
    {
        public bool Equals(List<string> x, List<string> y)
        {
            return x.SequenceEqual(y);
        }
        public int GetHashCode(List<string> obj)
        {
            int hashCode = 0;
            foreach (string str in obj)
            {
                hashCode ^= str.GetHashCode();
            }
            return hashCode;
        }
    }
