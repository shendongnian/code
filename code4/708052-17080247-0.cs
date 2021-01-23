    public class Foo
    {
        public int Member { get; set; }
        private static Foo instance = new Foo();
        public static Foo Instance { get { return instance; } }
        private Foo()
        {
        }
        public static implicit operator int(Foo foo)
        {
            return foo.Member;
        }
    }
