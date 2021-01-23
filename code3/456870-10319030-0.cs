    public class MyClass
    {
       public static void SomeMethod();
    }
    var instance = new MyClass();
    (instance as MyClass).SomeMethod() //THIS WILL NOT WORK
