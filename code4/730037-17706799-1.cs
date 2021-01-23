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
                      log.Error(ex.Message);
                      throw; // await will re-throw this
                 }
                 catch (Exception ex)
                 {
                      log.Error(ex.Message);
                 }
             });
    
             DoSomethingElse(); // does not run when some special exception occurs.
          }
          catch (SomeSpecialException ex)
          {
              // Here we are also running on captured SynchronizationContext
              // So, can update UI to show error ....
          }
    }
