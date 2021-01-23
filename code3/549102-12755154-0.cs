    class Foo { 
       void Bar() { Console.WriteLine("Foo.Bar"); }
    }
    class Bar { 
       void Baz() { Console.WriteLine("Bar.Baz"); }
    }
    public static dynamic Test(char c)
    {
       if (c == 'f') return new Foo();
       else return new Bar();
    }
