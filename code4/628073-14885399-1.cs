    public class Foo
    {
        private readonly static IDictionary<string, int> bar =
            new Dictionary<string, int>();
        public static IDictionary<string, int> Bar
        {
            // now any calls like Foo.Bar.Clear(); will not clear Foo.bar
            get { return new Dictionary<string, int>(bar); }
        }
    }
