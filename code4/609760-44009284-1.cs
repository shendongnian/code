    public class Test
    {
         public static object SomeProp(){ return new object(); }
    }
    public static void Main()
    {         
         Test Test = new Test();
         Test.SomeProp();//Works
    }
