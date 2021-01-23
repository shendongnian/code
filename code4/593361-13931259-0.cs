    static void Main()
    {
        // Create a new FileSystemWatcher and set its properties.
        FileSystemWatcher watcher = new FileSystemWatcher();
        watcher.Path = @"\\yourserver\yourshare";
        watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
               | NotifyFilters.FileName | NotifyFilters.DirectoryName;
        // Only watch text files.
        watcher.Filter = "*.txt";
    
        // Add handler for errors.
        watcher.Error += new ErrorEventHandler(OnError);
    
        // Begin watching.
        watcher.EnableRaisingEvents = true;
    
        // Wait for the user to quit the program.
        Console.WriteLine("Press \'q\' to quit the sample.");
        while(Console.Read()!='q');
    }
    private static void OnError(object source, ErrorEventArgs e)
    {
        //  Show that an error has been detected.
        Console.WriteLine("The FileSystemWatcher has detected an error");
    
        //  Give more information if the error is due to an internal buffer overflow.
        Type t = e.GetException().GetType();
        Console.WriteLine(("The file system watcher experienced an error of type: " + 
                           t.ToString() + " with message=" + e.GetException().Message));
    }
