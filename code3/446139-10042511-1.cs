    class MyClass
    {
        public string str;
    }
    static void MyMethod(ref MyClass obj)
    {
        obj.str = "Hello World";
        obj = null;
    }
    static void Main(string[] args)
    {
        MyClass o = new MyClass();
        o.str = "Hello";
        Console.WriteLine(o.str);
        MyMethod(ref o);
        Console.WriteLine(o.str); // prints "Hello World"
    }
