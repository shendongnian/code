    svcClient.GetType().InvokeMember(
       methodName, /* what you want to call */
       /* 
          Specifies what kinds of actions you are going to do and where / how 
          to look for the member that you are going to invoke 
        */
       System.Reflection.BindingFlags.Public | 
         System.Reflection.BindingFlags.NonPublic |
         System.Reflection.BindingFlags.Instance | 
         System.Reflection.BindingFlags.InvokeMethod, 
       null,      /* Binder that is used for binding */
       svcClient, /* the object to call the method on */
       null       /* argument list */
     );
