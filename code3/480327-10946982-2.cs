    class Program
    {
        static void Main(string[] args)
        {
            Delegation.MethodCaller mc1 = new Delegation.MethodCaller(Delegation.Method1);
            Delegation.MethodCaller mc2 = new Delegation.MethodCaller(Delegation.Method2);
            mc1.BeginInvoke(null, null);
            mc2.BeginInvoke(null, null);
            Console.ReadLine();
        }
        class Delegation
        {
            public delegate void MethodCaller();
            public static void Method1()
            {
                Console.WriteLine("Method 1 Invoked");
                Thread.Sleep(2000);
                Console.WriteLine("Method 1 Completed");
            }
            public static void Method2()
            {
                Console.WriteLine("Method 2 Invoked");
                Thread.Sleep(2000);
                Console.WriteLine("Method 2 Completed");
            }
        }
    }
