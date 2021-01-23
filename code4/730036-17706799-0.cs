    private async Task Test()
    {
             await Task.Run(() =>
             {
                 try
                 {
                      DoingSomething();
                 }
                 catch (Exception ex)
                 {
                      log.Error(ex.Message);
                 }
             });
          
    }
