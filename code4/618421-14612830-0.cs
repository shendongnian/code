    abstract class FooBase
    {
        public struct Bar
        {
             
        }
    }
    class Foo : FooBase
    {
        public readonly Bar BarInstance = new Bar();
    }
    class TestClass
    {
        public static void Test()
        {
            var foo = new Foo();
            var bar = foo.BarInstance; //works fine
        }
    }
