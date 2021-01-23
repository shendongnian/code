    BackgroundWorker backgroundWorker = new BackgroundWorker();
    backgroundWorker.WorkerReportsProgress = true;
    var context = SynchronizationContext.Current;
    var filesList = // clone your listToConver if it's not a local variable or other threads can access it
    backgroundWorker.DoWork += (s3, e3) =>
                   {
                       foreach (string file in filesList)
                       {
                           var newFile = sendFilesToConvert(file);
                           context.Post(x => listBoxFiles.Items.Add(newFile), null);
                                       
                           // Report progress
                       }
                   };
    backgroundWorker.RunWorkerAsync();
