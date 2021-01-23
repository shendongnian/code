    Public Class A
    {
    
     public A()
      {
    
        B_Object.DataLoaded += (sender, e) =>
                    {
                       Line 1
                       Line 2
                       Line 3
                       Line 4
                    };
      }
    
      Public override void Dispose()
      {
       if(B_Object.DataLoaded != null)
       {
         B_Object.DataLoaded -=
             (YourDelegateType)B_Object.DataLoaded.GetInvocationList().Last();
           //if you are not sure that the last method is yours than you can keep an index
           //which is set in your ctor ...
       }
      }
     }
     
