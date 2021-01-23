    class Program
    {
        static void Main(string[] args)
        {
            IA iface = new A();
            A cls = new A();
            iface.Test();
            cls.Test();
            Console.ReadKey();
        }
    }
    interface IA
    {
        void Test();
    }
    class A : IA
    {
        public void Test()
        {
            Console.WriteLine("Class");
        }
        void IA.Test()
        {
            Console.WriteLine("Interface");
        }
    }
