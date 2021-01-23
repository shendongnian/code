    namespace ConsoleApplication8
    {
        using MyLibrary;
        using static MyLibrary.MyHelpers;
        class Foo { }
        class Bar { }
        class Moo { }
        class Cow { }
        internal class Program
        {
            private static void Main(string[] args)
            {
                var cow = getfoo()?.getbar()?.getmoo()?.getcow();
            }
        }
    }
    namespace MyLibrary
    {
        using ConsoleApplication8;
        static class MyExtensions
        {
            public static Cow getcow(this Moo moo) => null;
            public static Moo getmoo(this Bar bar) => null;
            public static Bar getbar(this Foo foo) => null;
        }
        static class MyHelpers
        {
            public static Foo getfoo() => null;
        }
    }
