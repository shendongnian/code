    public void SetPriorityProcessAndTheards(string nameProcess,ProcessPriorityClass processPriority, ThreadPriorityLevel threadPriorityLevel)
    {
        foreach(Process a in Process.GetProcessesByName(nameProcess))
        {
            a.PriorityBoostEnabled = true;
            a.PriorityClass = processPriority;
                
            foreach(ProcessThread processThread in a.Threads)
            {
                processThread.PriorityLevel = threadPriorityLevel;
                processThread.PriorityBoostEnabled = true;
            }
        }
    }
