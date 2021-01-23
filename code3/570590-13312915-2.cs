    Stack<string> filelist = new Stack<string>() {"file1", "file2"};
    
    private void Setup()
    {
        System.ComponentModel.BackgroundWorker backgroundWorker1;
        System.ComponentModel.BackgroundWorker backgroundWorker2;
        backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
        backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
        backgroundWorker2.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
        backgroundWorker2.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
    }
    private void Execute()
    {
        backgroundWorker1.DoWork();
        backgroundWorker2.DoWork();
    }
    private string GetNextItem()
    {
        //this is a crude controller
        return filelist.Pop();
    }
    
    private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {   
        // Get the BackgroundWorker that raised this event.
        BackgroundWorker worker = sender as BackgroundWorker;
        string nextFile = GetNextItem();
        //Some simple check here to see if there were any items left or quit
        ....
        //Now do work
        Args = "-i " + nextFile  + " -r -c -noerr";
        DoWork(ArgDir, ExeName, Args, "3");
        
    }
    private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {   
        // Check for errors...
        ...
        // See if more work to do
        if (filelist.Count > 0)
        {
            //Repeat task
            BackgroundWorker worker = sender as BackgroundWorker;
            worker.DoWork();
        }
    }
