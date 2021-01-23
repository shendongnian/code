    var proc = Process.Start("notepad");
    try
    {
        while (proc.MainWindowHandle == IntPtr.Zero)
        {
            // Discard cached information about the process
            // because MainWindowHandle might be cached.
            proc.Refresh();
            Thread.Sleep(10);
        }
        var handle = proc.MainWindowHandle;
    }
    catch
    {
        // The process has probably exited,
        // so accessing MainWindowHandle threw an exception
    }
