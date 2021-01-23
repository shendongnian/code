    for(int i = 0; i < 10; i++)
    {
        bool isRunning = true;
        while(isRunning)
        {
           isRunning = CheckIfSomethingIsStillRunning();
           Thread.Sleep(10);
        }
    }
