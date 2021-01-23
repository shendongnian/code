    class Widget
    {
       private static readonly object X = new object() ;
       public void Foo()
       {
         lock(X)
         {
           // Do work using shared resource
         }
         return ;
       }
    }
