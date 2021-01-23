    public class ClassA
    {
      public void DoStuff()
      {
        MyVirtual();
      }
    
      protected virtual void MyVirtual()
      {
        Console.WriteLine("Base MyVirtual Called");
      }
    }
    
    public class ClassB : ClassA
    {
      protected override void MyVirtual()
      {
        Console.WriteLine("Overridden MyVirtual Called");
      }
    }
    
    ClassA test = new ClassB();
    test.DoStuff();
