    private static int totalCount = 0;
    private static double maxCount = 3;
    private static TimeSpan timeLimit = TimeSpan.FromSeconds(60);
    private static DateTime lastIncrementTime;
    
    private static void TestEvent(object src, EventArgs mea)
    {
        // If the time between now and lastIncrementTime is more than the timeLimit...
        if(DateTime.Now - lastIncrementTime > timeLimit)
        {
            totalCount = 0;
        }
        lastIncrementTime = DateTime.Now;
        totalCount++;     
        if (totalCount > maxCount)
        {
            DoSomething();
        }
    }
