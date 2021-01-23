    public sealed class Grob : IOldNewGrob
    {
        private static readonly Grob instance = new Grob();
        public static Grob Instance { get { return instance; } }
        // Prevent external instantiation
        private Grob() {}
        public static void Frob()
        {
            Foo.Bar();
        }
        // Implement IOldNewGrob here
    }
