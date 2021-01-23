    class Foo
    {
        static int count = 0;
        int fooNum;
        string name;
        public Foo()
        {
            ++count;
            fooNum = count;
            name = "Foo" + fooNum;
            Console.WriteLine(name);
        }
    }
    static void Main(string[] args)
    {
        for (int i = 0; i < 5; i++)
        {
            Foo test = new Foo();
        }
    }
