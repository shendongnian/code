    public class Test
    {
         public static void SomeMethod(){}
    }
    public static void Main()
    {         
         object Test = new Test();
         Test.SomeMethod();////ERROR... object does not have a instance method SomeMethod
    }
