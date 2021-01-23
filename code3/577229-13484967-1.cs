    static void Main(string[] args)
    {
        MyStruct[] l = new MyStruct[]
            {
                new MyStruct(0)
            };
        Console.WriteLine(l[0].Value);
        l[0].Change(10);
        Console.WriteLine(l[0].Value);
        IChangeStruct i = l[0];
        Console.WriteLine(i.Value);
        i.Change(5);
        Console.WriteLine(i.Value);
        Console.ReadLine();
    }
