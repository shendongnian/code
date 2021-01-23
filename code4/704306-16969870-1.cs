    delegate void SimpleDelegate(bool x = true);
    static void Main()
    {
        SimpleDelegate x = Foo;
        x(); // Will print "True"
     }
     static void Foo(bool y)
     {
         Console.WriteLine(y);
     }
