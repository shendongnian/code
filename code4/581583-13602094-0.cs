    var test = new Dictionary<string, string>(new MyStringEqualityComparer());
...
    public class MyStringEqualityComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return x.Split('|')[0] == y.Split('|')[0];
        }
        public int GetHashCode(string obj)
        {
            return obj.Split('|')[0].GetHashCode();
        }
    }
