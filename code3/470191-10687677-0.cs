    class Program
    {
        static void Main(string[] args)
        {
            ArrayList dummyfoo = new ArrayList();
            Foo a = new Foo(1);
            dummyfoo.Add(a);
            foreach (Foo x in dummyfoo)
                x.dummy++;
            Console.WriteLine(a.dummy); //Prints 2!
        }
    }
    class Foo
    {
        public int dummy;
        public Foo(int dummy)
        {
            this.dummy = dummy;
        }
    }
