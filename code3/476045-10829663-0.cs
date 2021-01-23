    public class MyEqualityComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return FixString(x).Equals(FixString(y), StringComparison.InvariantCultureIgnoreCase);
        }
        private string FixString(string x)
        {
            //remove hyphens
            return x.Replace("-", "");
        }
        public int GetHashCode(string obj)
        {
            return FixString(obj).GetHashCode();
        }
    }
