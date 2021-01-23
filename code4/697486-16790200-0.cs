    private List<string> _files;
    
    private void btnAddDir_Click(object sender, EventArgs e)
    {
        try
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
    		
    			_files = SafeFileEnumerator.EnumerateFiles(folderBrowserDialog1.SelectedPath, "*.*", SearchOption.AllDirectories)
    			
    			Interlocked.Increment(ref numWorkers);
    			var file = _files.FirstOrDefault();
    			if(file != null)
    				StartBackgroundFileChecker(file);
            }
        }
        catch (Exception)
        { }
    }
    
    private void StartBackgroundFileChecker(string file)
    {
        ListboxFile listboxFile = new ListboxFile();
        listboxFile.OnFileAddEvent += listboxFile_OnFileAddEvent;
        BackgroundWorker backgroundWorker = new BackgroundWorker();
        backgroundWorker.WorkerReportsProgress = true;
        backgroundWorker.DoWork +=
        (s3, e3) =>
        {
            //check my file
        };
    
        backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
        backgroundWorker.RunWorkerAsync();
    }
    
    void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        if (Interlocked.Decrement(ref numWorkers) == 0)
        {
            //update my UI
    		_files = _files.Skip(1);
    		var file = _files.FirstOrDefault();
    		if(file != null)
    			StartBackgroundFileChecker(file);
        }
    }
