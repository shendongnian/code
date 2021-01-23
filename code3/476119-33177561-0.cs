    public class A
    {
      protected void Test() { /* ... */ }
    
      protected static void Test(A obj)
      {
        a.Test();
      }
    }
    
    public class B : A
    {
      public void Test2()
      {
        A obj = new A();
        A.Test(obj);
      }
    }
