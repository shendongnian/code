    class MyClass
    {
        public Wrapped<string> SharedString { get; set; } 
    }
    var c1 = new MyClass();
    var c2 = new MyClass();
 
    var s = new Wrapped<string> { Item = "Hello" };
    c1.SharedString = s;
    c2.SharedString = s;
    c1.SharedString.Item = "World";
    Console.Writeline(c2.SharedString.Item);
