    public struct MyStruct
    { 
    }
    class Program
    {
        static void Main(string[] args)
        {
            test1();
            test2();
        }
        public static void test1()
        {
            Stopwatch sw = new Stopwatch();
            bool b;
            MyStruct s;
            for (int i = 0; i < 100000000; i++)
            {
                b = (object)s == null;
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
            Console.ReadLine();
        }
        public static void test2()
        {
            Stopwatch sw = new Stopwatch();
            bool b;
            MyStruct? s = null;
            for (int i = 0; i < 100000000; i++)
            {
                b = (object)s == null;
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
            Console.ReadLine();
        }
    }
