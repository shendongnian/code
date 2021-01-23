    var proc = Process.Start("notepad");
    while (proc.MainWindowHandle == IntPtr.Zero)
    {
        Thread.Sleep(10);
        // Or something like: Application.DoEvents();
    }
    var handle = proc.MainWindowHandle;
