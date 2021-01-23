    public class A
    {
      protected void Test()
      {
          // some code....
      }
    }
    
    public class B : A
    {
      public void Test2()
      {
        this.Test();
      }
    }
