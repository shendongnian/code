    class Parent
    {
        void Foo() { Console.WriteLine("Parent"); }
        virtual void Bar { Console.WriteLine("Parent"); }
    }
    
    class Child : Parent
    {
        new void Foo() { Console.WriteLine("Child"); } // another method Foo
        override void Bar { Console.WriteLine("Child"); }
    }
    
    var child = new Child();    // a Child instance
    var parent = (Parent)child; // same object, but statically typed as Parent
    
    c.Bar(); // prints "Child"
    p.Bar(); // again, prints "Child" -- expected virtual behavior
    
    c.Foo(); // prints "Child"
    p.Foo(); // but this prints "Parent"!!
