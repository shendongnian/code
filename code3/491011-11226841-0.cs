    public Foo()
    {
        {
            int bar = 10;
            Console.WriteLine(bar);
        }
        Console.WriteLine(bar); //Error: "Cannot resolve symbol bar."  It does not exist in this scope.
        {
            int bar = 20;  //Declare bar again because the first bar is out of scope.
            Console.Writeline(bar);
        }
    }
