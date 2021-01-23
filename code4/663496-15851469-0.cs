    public class MyComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y) { return x.StartsWith(y); }
        public int GetHashCode(string obj) { //some code }
    }
