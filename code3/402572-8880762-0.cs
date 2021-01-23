    public class TestClass
    {
       private BackgroundWorker worker;
    
       public void DoSomeWorkAsync()
       {
          this.worker = new BackgroundWorker();
          this.worker.DoWork += this.OnDoWork;
          this.worker.RunWorkerCompleted += this.OnWorkerComplete;
          this.worker.RunWorkerAsync();
       }  
    
       private void OnDoWork(object sender, DoWorkEventArgs e)
       {
          //do long running process here to pass to calling thread.
          //note this will execute on a background thread
          DataTable DT = GetSomeData();
          e.Result = DT;
       }
    
       private void OnWorkerComplete(object sender, RunWorkerCompletedEventArgs e)
       {
          //note this event is fired on calling thread
          if (e.Error != null)
             //do something with the error
          else if (e.Cancelled) 
             //handle a cancellation
          else
             //grab the result
             foo = e.Result;
       }
    }
