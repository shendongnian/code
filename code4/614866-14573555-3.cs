    public static TimeSpan GetInactiveTime(Thread t)
    {
        // if thread isn't sleeping anymore update its time
        if (t.ThreadState != ThreadState.WaitSleepJoin)
            lastActiveTime[t] = DateTime.Now;
        return DateTime.Now - lastActiveTime[t];
    }
