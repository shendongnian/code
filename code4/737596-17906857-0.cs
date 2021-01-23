    class Program
    {
        static P1 p = new P1();
        static void Main(string[] args)
        {
            var t = new P2();
            p = t;
            ((P2)p).DoWork();
            t.DoWork();
            Console.ReadLine();
        }
    }
