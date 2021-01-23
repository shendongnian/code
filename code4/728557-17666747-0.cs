    public static class StaticyGoodness
    {
        public static void Main()
        {
            var someAs = new List<A>();
            var someBs = new List<B>(); // get it?
            DoTheThings(someAs);
            // Doing things the regular way
            DoTheThings(someBs);
            // Doing things the SPECIALIZED way
            DoTheThings(someBs.OrderBy(b => b.Stuff));
            // Doing things the REALLY SPECIALIZED way
        }
        private static void DoTheThings<T>(this IEnumerable<T> source)
        {
            Console.WriteLine("Doing things the regular way");
        }
        private static void DoTheThings(this IEnumerable<B> source)
        {
            Console.WriteLine("Doing things the SPECIALIZED way");
        }
        private static void DoTheThings(this IOrderedEnumerable<B> source)
        {
            Console.WriteLine("Doing things the REALLY SPECIALIZED way");
        }
    }
    public class A { }
    public class B : A { public int Stuff { get; set; } }
