    public class Test
    {
      static int a = 0;
      public int SomeMethod() { a = a + 1; return a; }
    }
    
    Test t1 = new Test();
    t1.SomeMethod(); // a is now 1
    Test t2 = new Test();
    t2.SomeMethod(); // a is now 2
   
    // If 'a' wasn't static, each Test instance would have its own 'a'
