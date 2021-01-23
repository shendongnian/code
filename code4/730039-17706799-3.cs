    private async Task Test()
    {
         try
         {
             await Task.Run(() =>
             {
                 try
                 {
                      DoingSomething();
                 }
                 catch (SomeSpecialException spex)
                 {
                      // it is OK to have this exception
                      log.Error(ex.Message);
                 }
             });
    
             DoSomethingElse(); // does not run when unexpected exception occurs.
          }
          catch (Exception ex)
          {
              // Here we are also running on captured SynchronizationContext
              // So, can update UI to show error ....
          }
    }
