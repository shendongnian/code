    public class Bar{}
    namespace Foo
    {
        public class Bar {}
        public class Test
        {
            static void Main()
            {
                Bar bar1 = null; // Refers to Foo.Bar
                global::Bar bar2 = null; // Refers to the "top level" Bar
            }
        }
    }
