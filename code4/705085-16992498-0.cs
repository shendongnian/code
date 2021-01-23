       private static Object lockGuard = new Object();
       public void DoSomething()
       {
         lock (lockGuard) 
          {
              //logic gere
          }
        }
