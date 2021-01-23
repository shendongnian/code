    private static int totalCount = 0;
    private static double maxCount = 3;
    private static double timeLimit = 60;
    private static DateTime  timeflag= DateTime.Now;
    private static void TestEvent(object src, EventArgs mea)
    {
        if (timeflag.AddSeconds(timeLimit) < DateTime.Now)
        {
            totalCount = 0;
        }
        totalCount++;
        timeflag = DateTime.Now;
        if (totalCount > maxCount)
        {
                DoSomething();
        }
    }
