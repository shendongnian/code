    class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.Name = "Console Thread";
            var a = new A();
            a.A1();
            Console.WriteLine("Press return to exit...");
            Console.Read();
        }
    }
    public class A
    {
        public void A1()
        {
            var b = new B();
            b.B2();
            b.WaitForSet();
            Console.WriteLine("Signal received by " +  Thread.CurrentThread.Name + " should be ok to check value of X");
            Console.WriteLine("Value of X = " + b.X);
        }
    }
    public class B
    {
        private AutoResetEvent S = new AutoResetEvent(false);
        public bool X { get; private set; } 
        public void B1()
        {
            X = true;
            Console.WriteLine("X set to true by " + Thread.CurrentThread.Name);
            S.Set();
            Console.WriteLine("Release the hounds signal by " + Thread.CurrentThread.Name);
        }
        public void B2()
        {
            Console.WriteLine("B2 starting thread...");
            var thread = new Thread(new ThreadStart(B1)) { Name = "B Thread" };
            thread.Start();
            Console.WriteLine("Value of X = " + X + " Thread started.");
        }
        public void WaitForSet()
        {
            S.WaitOne();
            Console.WriteLine(Thread.CurrentThread.Name + " Waiting one...");
        }
    }
