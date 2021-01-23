    static void Main(string[] args)
    {
        myclass c = new myclass();
        c.test1 = 1;
        myclass c2 = TestPassByValByRef(c);
        Console.WriteLine("c.Test1: {0}", c.test1);
        Console.WriteLine("c2.Test1: {0}", c2.test1);
        Console.ReadLine();
    }
