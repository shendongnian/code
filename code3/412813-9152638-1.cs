    public static Thread testThread = new Thread(ThreadStart) 
    {
        Name = "TestThread", 
        IsBackground = false    // Allow thread to terminate naturally
    };
    private static volatile bool isTerminating = false;   // Sentinel
    private void Form_Load()
    {
        testThread.Start();
        Thread.Sleep(200);      // Sleep 200 milliseconds
        isTerminating = true;   // Set sentinel to terminate thread
    }
    private static void ThreadStart()
    {
        int count = 0;
        while (!isTerminating)   // Keep looping until sentinel is set
            count++;
    
        using (StreamWriter stream = new StreamWriter(File.OpenWrite("Result.txt")))
        {
            stream.WriteLine(count);
            stream.Flush();
        }
    }
