    var result = urls.Distinct(new UrlComparer());
---
    public class UrlComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return new Uri(x).Host == new Uri(y).Host;
        }
        public int GetHashCode(string obj)
        {
            return new Uri(obj).Host.GetHashCode();
        }
    }
