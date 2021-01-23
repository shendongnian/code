    public void StartProcessThread(string targetDirectory)
    {
        Thread T = new Thread(new ParameterizedThreadStart(ProcessDirectory));
        T.Start(targetDirectory);
    }
    public void ProcessDirectory(object objTargetDirectory)
    {
        string targetDirectory = (string)objTargetDirectory;
        // Process the list of files found in the directory.
        try
        {
            var fileEntries = Directory.GetFiles(targetDirectory);
    
            foreach (var fileName in fileEntries)
            {
                ProcessFile(fileName);
            }
        }
        catch (Exception e){}
        // Recurse into subdirectories of this directory.
        try
        {
            var subdirectoryEntries = Directory.GetDirectories(targetDirectory);
    
            foreach (string subdirectory in subdirectoryEntries)
                ProcessDirectory(subdirectory);
        }
        catch (Exception e){}
    }
    
    
    public void ProcessFile(string path)
    {
        Dispatcher.Invoke(new Action() {
            myListBox.Items.Add(path);  
        });
    }
