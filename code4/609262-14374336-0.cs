    System.Threading.Tasks.Task.Factory.StartNew(() =>
    {                
       return expensiveTaskResults();
    }).ContinueWith(t =>
    {
       if (t.IsFaulted) HandleError(t);                
       Result = t.Result;
    }
