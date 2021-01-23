    public class Class1
    {
      public static void Aaa(short a)
      {
        
      }
      public void Bbb()
      {
        int i = 5;
        byte b = 1;
        short c = 1;
        Class1.Aaa(i); // Gives error
        Class1.Aaa(b); // Ok
        Class1.Aaa(c);  // ok
      }
    }
