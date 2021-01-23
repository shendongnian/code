    /// <summary>
    /// Watching Process to restart the application.
    /// </summary>
    class Programm
    {
        static void Main(string[] args)
        {
            // Create a Mutex which so the watcher Process 
            using (var StartStopHandle = new Mutex(true, "MyApplication.exe"))
            {
                // Try to get Mutex ownership. 
                if (StartStopHandle.WaitOne())
                { 
                    // Start the Watch process here
                    Process.Start("MyApplication.exe");
    
                    // Quit after starting the Application.
                }
            }
        }
    }
