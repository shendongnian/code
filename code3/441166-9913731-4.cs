    class A
            {
                public static void Foo() { }
            }
        static class Ext
        {
            public static void Foo(this A me, int i)
            { }
        }
        class Program
        {
            static void Main(string[] args)
            {
                A a = new A();
                a.Foo(10);
                Console.ReadLine();
            }
        }
