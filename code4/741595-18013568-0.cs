    class Program
    {
        static void Main(string[] args)
        {
            Test t1 = new Test();
            t1.i = 1;
            t1.o = new Klasse();
            t1.o.i = 1;
            Test t2 = t1;
            t2.i = 2;
            t2.o.i = 2;
            Console.WriteLine(t1.i.ToString());
            Console.WriteLine(t1.o.i.ToString());
            Console.WriteLine(t2.i.ToString());
            Console.WriteLine(t2.o.i.ToString());
            Console.Read();
        }
    }
    struct Test
    {
        public int i;
        public Klasse o;
    }
    class Klasse
    {
        public int i = 0;
    }
