    class Program
    {
        static void Main(string[] args)
        {
            D test = new D();
        }
    }
    class C
    {
        private C() { }
    }
    interface IFoo<T> where T : C, new() { }
    class D : C
    {
        public D()
            : this(5) { }
        public D(int x)
            : this() { }
    }
    class Dfoo : IFoo<D> { }
