      public void Dispose()
      {
          if (isAlive && ShouldDispose())
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
