    class Program
    {
        static void Main(string[] args)
        {
            Test1();
            Test2();
        }
        public static void Test1()
        {
            Action a = () => Console.WriteLine("A");
            Action b = () => Console.WriteLine("B");
            Action c = a + b;
            c();
        }
        public static void Test2()
        {
            Action a = () => Console.WriteLine("A");
            Action b = () => Console.WriteLine("B");
            Action c = (Action)MulticastDelegate.Combine(a, b);
            c();
        }
    }
