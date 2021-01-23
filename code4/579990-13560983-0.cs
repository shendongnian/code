    using System;
    interface IFoo
    {
        void Bar();
    }
    struct ExplicitImpl : IFoo
    {
        void IFoo.Bar() { Console.WriteLine("ExplicitImpl"); }
    }
    struct ImplicitImpl : IFoo
    {
        public void Bar() {Console.WriteLine("ImplicitImpl");}
    }
    static class FooExtensions
    {
        public static void Bar<T>(this T foo) where T : IFoo
        {
            foo.Bar();
        }
    }
    static class Program
    {
        static void Main()
        {
            var expl = new ExplicitImpl();
            expl.Bar(); // via extension method
            var impl = new ImplicitImpl();
            impl.Bar(); // direct
        }
    }
