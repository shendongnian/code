    public class Program
    {
        static void Main(string[] args)
        {
            var a = new A();
            a.Attach();
            a.doSomething();
        }
    }
    public class A
    {
        public delegate void handler();
        public handler doSomething;
        private void P1()
        {
            Console.WriteLine("Inaccessible");
        }
        public void P2()
        {
            Console.WriteLine("Accessible");
        }
        public void Attach()
        {
            doSomething += P1;
            doSomething += P2;
        }
    }
