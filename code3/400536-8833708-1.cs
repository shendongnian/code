    private class IgnoreWWWEqComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            if(ReferenceEquals(x, y))
                return true;
            if(x == null || y == null)
                return false;
            if(x.StartsWith("www."))
            {
                if(y.StartsWith("www."))
                    return x.Equals(y);
                return x.Substring(4).Equals(y);
                //the above line can be made faster, but this is a reasonable
                //approach if performance isn't critical
            }
            if(y.StartsWith("www."))
                return x.Equals(y.Substring(4));
            return x.Equals(y);
        }
        public int GetHashCode(string obj)
        {
            if(obj == null)
                return 0;
            if(obj.StartsWith("www."))
                return obj.Substring(4).GetHashCode();
            return obj.GetHashCode();
        }
    }
