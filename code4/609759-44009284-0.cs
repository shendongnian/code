    public class Test
    {
         public static object SomeProp(){ return new object(); }
    }
    public static void Main()
    {
         Test.SomeProp();//ERROR... cannot use variable before declaring it.
         object Test = new object();
         Test.SomeProp();//ERROR... object does not have a method test
    }
