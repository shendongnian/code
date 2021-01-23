       public class A
       {
          protected int x;
        
          public class B
          {
              public static A CreateClassA()
              {
                  A x = new A();
                  x.x = 5;   // ERROR : No privilege
                  return x;
              }
          }
       }
