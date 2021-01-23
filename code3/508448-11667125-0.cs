    private static void OnError(object source, ErrorEventArgs e)
    {
        if (e.GetException().GetType() == typeof(InternalBufferOverflowException))
        {
            //  This can happen if Windows is reporting many file system events quickly 
            //  and internal buffer of the  FileSystemWatcher is not large enough to handle this
            //  rate of events. The InternalBufferOverflowException error informs the application
            //  that some of the file system events are being lost.
            Console.WriteLine(("The file system watcher experienced an internal buffer overflow: " + e.GetException().Message));
        }
    }
