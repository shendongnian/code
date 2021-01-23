    [DllImport("user32.dll")]
    private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
    // console application entry point
    static void Main()
    {
        // check if process already runs, otherwise start it
        if(Process.GetProcessesByName("OUTLOOK").Count().Equals(0))
            Process.Start("OUTLOOK");
        // get running process
        var process = Process.GetProcessesByName("OUTLOOK").First();
        // as long as the process is active
        while (!process.HasExited)
        {
            // title equals string.Empty as long as outlook is minimized
            // title starts with "öffnen" (engl: opening) as long as the programm is loading
            string title = Process.GetProcessById(process.Id).MainWindowTitle;
            // "posteingang" is german for inbox
            if (title.ToLower().StartsWith("posteingang"))
            {
                // minimize outlook and end the loop
                ShowWindowAsync(Process.GetProcessById(process.Id).MainWindowHandle, 2);
                break;
            }
            //wait awhile
            Thread.Sleep(100);
            // place for another exit condition for example: loop running > 1min
        }
    }
