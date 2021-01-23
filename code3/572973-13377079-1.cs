    // make sure that path is always in form C:\Folder\file.txt - less chance of different 
    // paths pointing to the same file.
    filePath = System.IO.Path.GetFullPath(filePath);
    Process proc;
    if (this.OpenedProcesses.TryGetValue(filePath, out proc) && !proc.HasExited)
    {
        MessageBox.Show("The file is already open!");
        // it could be possible to activate the window of the open process but that is another question on its own.
        return;
    }
    proc = System.Diagnostics.Process.Start(filePath);
    this.OpenedProcesses[filePath] = proc;
