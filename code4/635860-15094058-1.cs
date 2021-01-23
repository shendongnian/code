    public class A
    {
       protected virtual int FieldTest { get { return 0; } }
       public void TestMethod()
       {
            Console.WriteLine ("FieldTest: " + FieldTest);
       }
    }
    
    public class B : A
    {
       protected override int FieldTest { get { return 5; } }
    }
    public class C : A 
    {
       protected override int FieldTest { get { return 10; } }
    }
