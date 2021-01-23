    public class myUIFormControlWhatever
    {
       ...
       public void CallTheBackgroundWorker()
       {
          myBackgroundWorker bgw = new myBackgroundWorker();
          // attach "listening" when the background worker reports changes
          bgw.ProgressChanged += thisObjectShowChangedProgress;
          bgw.RunWorkerAsync();
       }
    
       protected void thisObjectShowChangedProgress( object sender, ProgressChangedEventArgs e )
       {
          this.SomeTextShownOnUI = ((myBackgroundWorker)sender).ExposedProperty;
       }
    }
    
    
    public class myBackgroundWorker : BackgroundWorker
    {
       public myBackgroundWorker()
       {
          WorkerReportsProgress = true;
          // hook up internal to background worker any strings
          // you want to expose once reporting and any other listeners are out there.
          ProgressChanged += StatusUpdate;
       }
    
       protected void StatusUpdate( object sender, ProgressChangedEventArgs e )
       {
          // set property to what you want any other listeners to grab/display
          ExposedProperty = "something you are handling internally to background worker";
       }
    
       public string ExposedProperty
       { get; protected set; }
    
    }
