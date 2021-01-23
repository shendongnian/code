    static void MyMethod(MyClass *obj)
    {
        obj->str = "Hello World";
        obj = NULL;
    }
    static void Main(string[] args)
    {
        MyClass *o = new MyClass();
        o->str = "Hello";
        Console.WriteLine(o->str);
        MyMethod(o);
        Console.WriteLine(o->str); // prints "Hello World"
    }
