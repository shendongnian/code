    /// <summary>
    /// Main Program.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Create a Mutex which so the watcher Process 
            using (var StartStopHandle = new Mutex(true, "MyApplication.exe"))
            {
                // Start the Watch process here. 
                Process.Start("MyWatchApplication.exe");                
    
                // Your Program Code...
            }
        }
    }
