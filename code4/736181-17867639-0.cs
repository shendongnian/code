    interface I
    {
        Task Foo();
    }
    class A : I
    {
        public Task Foo()
        {
        }
    }
    class B : I
    {
        public async Task Foo()
        {
        }
    }
    public class Program
    {
        private static void Main(string[] args)
        {
            I i;
            if (Console.ReadLine() == "1")
            {
                i = new A();
            }
            else i = new B();
            i.Foo();
        }
    }
