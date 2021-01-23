    public class Test
    {
         public static void SomeMethod(){}
    }
    public static void Main()
    {
         Test.SomeMethod();//ERROR... cannot use variable before declaring it.
         object Test = new object();
         Test.SomeMethod();//ERROR... object does not have a method SomeMethod
    }
