    public void doWorkEvery(int interval)
    {
        while (true)
        {
            uint startTicks;
            int workTicks, remainingTicks;
            startTicks = (uint)Environment.TickCount;
            DoSomeWork();
            workTicks=(int)((uint)Environment.TickCount-startTicks);
            remainingTicks = interval - workTicks;
            if (remainingTicks>0) Thread.Sleep(remainingTicks);
        }
    }
