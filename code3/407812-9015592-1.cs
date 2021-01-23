    public class SomePropertyClass
    {
        public string VarA { get; set; }
        public string VarB { get; set; }
    }
    static class Program
    {
        static void Main(string[] args)
        {
            SomePropertyClass v1 = new SomePropertyClass() { VarA = "item 1" };
            SomePropertyClass v2 = new SomePropertyClass() { VarB = "item 2" };
            var yo = v1.Combine(v2);
        }
        static public IEnumerable<object> Combine<T, U>(this T one, U two)
        {
            var properties1 = one.GetType().GetProperties().Where(p => p.CanRead && p.GetValue(one, null) != null).Select(p => p.GetValue(one, null));
            var properties2 = two.GetType().GetProperties().Where(p => p.CanRead && p.GetValue(two, null) != null).Select(p => p.GetValue(two, null));
            return new List<object>(properties1.Concat(properties2));
        }
    }
