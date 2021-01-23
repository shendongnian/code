    using System;
    
    public class myForm
    {
       private static myForm Current;
    
       private myForm() {}
    
       public static myForm Instance
       {
          get 
          {
             if (Current == null)
             {
                Current = new myForm();
             }
             return Current;
          }
       }
    }
