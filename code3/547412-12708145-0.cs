    public class Foo1 : IFoo { public void Foo() { Console.WriteLine("Foo1"); } }
    
    public class Foo2 : IFoo { public void Foo() { Console.WriteLine("Foo2"); } }
    
    public class Foo3 : IFoo { public void Foo() { Console.WriteLine("Foo2"); } }
    
    _stack.Push(new Foo1());
    _stack.Push(new Foo2());
    _stack.Push(new Foo3());
