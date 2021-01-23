      public void Dispose()
      {
          if (ShouldDispose())
          {
              //Your code here
          }
      }
      
      [MethodImplAttribute(MethodImplOptions.Synchronized)]
      private bool ShouldDispose()
      {
           if (isAlive)
           {
                isAlive = false;
                return true;
           }
           return false;
      }
