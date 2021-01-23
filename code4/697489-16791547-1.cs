     private void btnAddDir_Click(object sender, EventArgs e)
     {
    Task.Factory.StartNew(() =>
            {
                var selectedPath = folderBrowserDialog1.SelectedPath;
                var files = Directory.EnumerateFiles(selectedPath, "*.*", SearchOption.AllDirectories);
                Parallel.ForEach(files,
                                 new ParallelOptions
                                     {
                                         MaxDegreeOfParallelism = 10//limit number of parallel threads here 
                                     },
                                 file =>
                                 {
                                     //process file here - launch your process
                                 });
            }).ContinueWith(t =>
            {
                //when all files processed.
                //Update your UI here
               
            },
                            TaskScheduler.FromCurrentSynchronizationContext() // to ContinueWith (update UI) from UI thread
                );
    }
