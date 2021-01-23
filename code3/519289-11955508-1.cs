    Task myTask= Task.Factory.StartNew( ... ).ContinueWith(myTaskFinished=> 
    {
       if (myTaskFinished.IsCompleted)
       {
           // Hooray
       }
       if (myTaskFinished.IsFaulted)
       {
           foreach (Exception ex in myTaskFinished.Exception.InnerExceptions)
               //Exception handle..
       }
       if(myTaskFinished.IsCanceled)
       { 
            //Cancellation token?
       }
    });
    myTask.Wait();
