    interface IMyDoable
    {
       int GetNumber();
    }
    
    class Foo : IMyDoable
    {
      ...
    
      public void UseFoo(Action<IMyDoable> action) { action(this); }
      public int GetNumber() { return this.number; }
    }
    
    class Bar : IMyDoable
    {
      ...
    
      public void UseBar(Action<IMyDoable> action) { action(this); } 
      public int GetNumber() { return 34; }
    }
    
    void Main()
    {
        Type fooType = GetType("Foo");
        int i = 0;
        Action<IMyDoable> doSomething = (foo) => i+= foo.GetNumber();
    
        var myFoo = Activator.CreateInstance(fooType);
        fooType.GetMethod("UseFoo").Invoke(myFoo, new object[] { doSomething });
        Console.WriteLine(i);
    }
