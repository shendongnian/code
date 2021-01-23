    class Program
    {
        static void Main(string[] args)
        {
            A a = new A(new A());
        }
    }
    public class A
    {
        public string Name { get; set; }
        public A a;
        public A() { }
        public A(A _a)
        {
            a = _a;
        }
    }
