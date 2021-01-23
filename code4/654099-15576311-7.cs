    public class ParameterComparer : IEqualityComparer<List<string>>
    {
        public bool Equals(List<string> x, List<string> y)
        {
            if (x == null && y == null) return true;
            if (x == null || y == null) return false;
            return x.SequenceEqual(y);
        }
        public int GetHashCode(List<string> obj)
        {
            if (obj == null) throw new ArgumentNullException("obj");
                
            // Note: this is not a safe way to get a hash code,
            // but if you're sure that the members are always ordered
            // and will never contain a semi-colon, then it will work.
            return string.Join(";", obj).GetHashCode();
        }
    }
    private static List<Object1> MergeLists(List<Object1> list1, List<Object1> list2)
    {
        var parameterComparer = new ParameterComparer();
        var distinctParameters = list1.Select(o => o.Parameters)
            .Concat(list2.Select(o => o.Parameters))
            .Distinct(parameterComparer);
        return (from p in distinctParameters
                let o1 = list1.SingleOrDefault(o => parameterComparer.Equals(p, o.Parameters))
                let o2 = list2.SingleOrDefault(o => parameterComparer.Equals(p, o.Parameters))
                let result = o2 ?? o1
                select result).ToList();
    }
