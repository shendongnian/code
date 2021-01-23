    public class Foo
    {
       public static string randomthing(string var1)
       {
          string var2 = "hello world";
          return var2;
       }
    }
    public class OtherClass
    {  
        public OtherClass()
        {
           // In constructor
           string here1 = Foo.randomthing("x");
        }
        public void OrInSomeFunction()
        {
           string here2 = Foo.randomthing("x");
        }
    }
