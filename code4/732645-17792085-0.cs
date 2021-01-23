    public partial class App : Application
    {
        // signals to restore the window to its normal state
        private const int SW_SHOWNORMAL = 1;
        // create the mutex
        private const string MUTEXNAME = "FirstInstance";
        private readonly Mutex _mutex = new Mutex(true, MUTEXNAME);
        public App()
        {
            if (!_mutex.WaitOne(TimeSpan.Zero))
            {
                ShowExistingWindow();
                Shutdown();
            }
        }
        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        // shows the window of the single-instance that is already open
        private void ShowExistingWindow()
        {
            var currentProcess = Process.GetCurrentProcess();
            var processes = Process.GetProcessesByName(currentProcess.ProcessName);
            foreach (var process in processes)
            {
                // the single-instance already open should have a MainWindowHandle
                if (process.MainWindowHandle != IntPtr.Zero)
                {
                    // restores the window in case it was minimized
                    ShowWindow(process.MainWindowHandle, SW_SHOWNORMAL);
                    // brings the window to the foreground
                    SetForegroundWindow(process.MainWindowHandle);
                    return;
                }
            }
        }
    }
