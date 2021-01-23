    private void fileSystemWatcher1_Created(object sender, System.IO.FileSystemEventArgs e)
    {
        if (!listBox1.Items.Contains(e.FullPath))
        {
            //add path
            listBox1.Items.Add(e.FullPath + "" + DateTime.Now.ToString());
            
            //start task
            startTask(e.FullPath);
        }
    }
    private void startTask(string path)
    {
        //start task
        Task t = Task.Factory.StartNew(() => runThis(path));
    }
    private void runThis(string path){}
