    static void Main()
    {
        Foo item = new Foo("aaa");
        GetByReference(ref item);
        Console.WriteLine(item.Name)
    }
    static void ChangeByReference(ref Foo itemRef)
    {
        itemRef = new Foo("bbb");
    }
