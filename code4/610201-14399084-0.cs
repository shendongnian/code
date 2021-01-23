    public class HelperClass
    {
       public static void M1()
       {
          // implementation code
       }
       public static void M2()
       {
          // implementation code
       }
    }
    
    public class A1:A
    {
       public void M1()
       {
           HelperClass.M1();
       }
       public void M2()
       {
           HelperClass.M2();
       }
    }
    
    public class B1:B
    {
       public void M1()
       {
           HelperClass.M1();
       }
       public void M2()
       {
           HelperClass.M2();
       }
    }
    
    public class C1:C
    {
       public void M1()
       {
           HelperClass.M1();
       }
       public void M2()
       {
           HelperClass.M2();
       }
    }
