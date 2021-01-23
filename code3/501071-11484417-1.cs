    Dictionary<string, int> dict = new Dictionary<string, int>(new Comparer());
    dict.Add("aa ", 10);
    int i = dict[" aa"];
    public class Comparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return x.Trim().Equals(y.Trim());
        }
        public int GetHashCode(string obj)
        {
            return obj.Trim().GetHashCode();
        }
     }
