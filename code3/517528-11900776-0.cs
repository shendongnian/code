    public void DoWork(object sender)
    {
         object s = (object)sender;
            
         this.Invoke(new ThreadDone(ReportProgress), result);
    }
