    using System;
    public class TopClass
    {
        public int retVal;
    }
    public class SubClassA : TopClass { }
    public class ThrowawayTest
    {
        private static T Bar<T>(T x) where T: class
        {
            // I have to use dynamic to force y to the dynamic type of x
            // after which Foo is bound (at runtime, not at compile time)
            dynamic y = x;
            return Foo(y);
        }
        private static TopClass Foo(TopClass x)
        {
            x.retVal = 1;
            return x;
        }
        private static SubClassA Foo(SubClassA x)
        {
            x.retVal = 2;
            return x;
        }
        public static void Main()
        {
            TopClass t = new TopClass();
            TopClass t1 = new SubClassA();
            SubClassA s1 = new SubClassA();
            t = Bar(t);
            t1 = Bar(t1);
            s1 = Bar(s1);
            if (1 != t.retVal)
                Console.WriteLine("t is messed");
            if (2 != s1.retVal)
                Console.WriteLine("s1 is messed");
            if (2 != t1.retVal)
                Console.WriteLine("t1 is messed");
        }
    }
