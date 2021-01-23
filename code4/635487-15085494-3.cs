    static void Main()
    {
        var c = new MyClass<int>(); //T is int
        c.MyField = 1;
        c.MyProp = 1;
        var myClass = c.MyMethod("2");
        myClass.MyField = "2";
        myClass.MyField = "4";
    }
