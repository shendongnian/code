    public void TraverseSource()
    {
        // create the BackgroundWorker
        var worker = new BackgroundWorker
                           {
                              WorkerReportsProgress = true
                           };
        
        // assign a delegate to the DoWork event, which is raised when `RunWorkerAsync` is called. this is where your actual work should be done
        worker.DoWork += (sender, args) => {
           string[] allFiles1 = Directory.GetFiles(sourcePath, "*.xml", SearchOption.AllDirectories);
    
            var allFiles = new ArrayList();
         
            foreach (var i = 0; i < allFiles1.Length; i++)
            {
                if (!item.Substring(item.Length - 6).Equals("MD.xml"))
                {
                    allFiles.Add(item);
                    // notifies the worker that progress has changed
                    worker.ReportProgress(i/allFiles.Length*100);
                }
            }
        };
        // assign a delegate that is raised when `ReportProgress` is called. this delegate is invoked on the original thread, so you can safely update a WinForms control
        worker.ProgressChanged += (sender, args) => {
           progressBar1.Value = args.ProgressPercentage;
        };
    
        // OK, now actually start doing work
        worker.RunWorkerAsync();
    
    }
