    class MyComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return x.ToUpper() == y.ToUpper();
        }
        public int GetHashCode(string obj)
        {
            return obj.ToUpper().GetHashCode();
        }
    }
    ...
    Dictionary<String, String> dict = new Dictionary<string, string>(new MyComparer());
