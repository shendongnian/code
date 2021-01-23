    public class C : A
    {
      public static void F(A a, B b, C c)
      {
         a.x = 1; // not allowed
         b.x = 1; // not allowed
         c.x = 1; // allowed
      }
    }
