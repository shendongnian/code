    static void Main(string[] args)
    {
        var myBlah = new EnhancedFooBox();
        Test2(myBlah); //first assign name to EnhancedFoo
        Test1(myBlah); //second assign name to FooBase
        Console.Write(myBlah.Foo.Name);
        Console.ReadKey();
    }
