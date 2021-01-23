    while(appIsRunning)
    {
        Thread.Sleep(100);
        lock(myQueue)
        {
            while(myQueue.Count > 0)
            {
               Console.WriteLine(myQueue.Dequeue());
            }
        }
    }
