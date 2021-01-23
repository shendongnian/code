    Task Test1()
    {
        int a = 0; // Will be called on the called thread.
        vat syncContext = Task.GetCurrentSynchronizationContext(); // This will help us go back to called thread
        return Task.Run(() => 
          {
               // We already on background task, so we safe here to wait tasks
               var bTask = this.GetValueAsync();
               bTask.Wait();
               int b = bTask.Result;
               // syncContext helps us to invoke something on main thread
               // because 'int c = 1;' probably was expected to be called on 
               // the caller thread
               var cTask = Task.Run(() => return GetC(), syncContext); 
               cTask.Wait();
               int c = cTask.Result;
 
               // This one was with 'await' - calling without syncContext, 
               // not on the thread, which calls our method.
               var dTask = this.GetValueAsync();
               dTask.Wait();
               int d = dTask.Result;
          });
    }
