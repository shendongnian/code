    public class fooBase
    {
         [CustomAttribute()]
         public string method1()
         {
             if (anotherFooMethod(typeof(fooBase)))
             {
                 ....
             }
         }
    }
