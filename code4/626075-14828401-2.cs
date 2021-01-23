    public class StaticTest
    {
        public static void Foo() { Console.WriteLine("Foo 1"); }
        public static void Bar() { Console.WriteLine("Bar 1"); }
    }
    public class StaticTest2 : StaticTest
    {
        public new static void Foo() { Console.WriteLine("Foo 2"); }
        public static void Some() { Foo(); Bar(); } // Will print Foo 2, Bar 1
    }
    public class TestStatic
    {
        static void Main(string[] args)
        {
            StaticTest2.Foo();
            StaticTest2.Some();
            StaticTest.Foo();
            Console.ReadLine();
        }
    }
