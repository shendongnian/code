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
        Test();  // Calls the test method in the base implementation of the CURRENT B object
      }
    }
