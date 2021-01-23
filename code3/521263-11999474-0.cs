    myWatcher.Changed += new FileSystemHandler(FSWatcherTest_Changed);
    private void FSWatcherTest_Changed(object sender, 
                    System.IO.FileSystemEventArgs e)
    {
        //code here for newly changed file or directory
    }
    
