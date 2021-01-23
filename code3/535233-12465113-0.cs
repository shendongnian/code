    static void Main()
    {
        const string directory = @"C:\Program Files";
        // Create an enumeration of the files we will want to process that simply accumulates these values...
        long total = 0;
        var fcounter = new CSharpTest.Net.IO.FindFile(directory, "*", true, true, true);
        fcounter.RaiseOnAccessDenied = false;
        fcounter.FileFound +=
            (o, e) =>
                {
                    if (!e.IsDirectory)
                    {
                        Interlocked.Increment(ref total);
                    }
                };
        // Start a high-priority thread to perform the accumulation
        Thread t = new Thread(fcounter.Find)
            {
                IsBackground = true, 
                Priority = ThreadPriority.AboveNormal, 
                Name = "file enum"
            };
        t.Start();
        
        // Allow the accumulator thread to get a head-start on us
        do { Thread.Sleep(100); }
        while (total < 100 && t.IsAlive);
        // Now we can process the files normally and update a percentage
        long count = 0, percentage = 0;
        var task = new CSharpTest.Net.IO.FindFile(directory, "*", true, true, true);
        task.RaiseOnAccessDenied = false;
        task.FileFound +=
            (o, e) =>
                {
                    if (!e.IsDirectory)
                    {
                        ProcessFile(e.FullPath);
                        // Update the percentage complete...
                        long progress = ++count * 100 / Interlocked.Read(ref total);
                        if (progress > percentage && progress <= 100)
                        {
                            percentage = progress;
                            Console.WriteLine("{0}% complete.", percentage);
                        }
                    }
                };
        task.Find();
    }
