    Thread thread = new Thread(delegate()
        {
            // Something that takes up to an hour
        });
    thread.Start();
    for (int minute = 0; minute < 60; minute++)
    {
        Thread.Sleep(60000);
        if (thread.IsAlive)
            Console.WriteLine("Still going after {0} minute(s).", minute);
        else
            break; // Finished early!
    }
    // Check if it's still running
    if (thread.IsAlive)
    {
        Console.WriteLine("Didn't finish after an hour, something may have screwed up!");
        thread.Abort();
    }
