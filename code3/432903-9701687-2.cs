    public static long GetTotalMemory(bool forceFullCollection)
    {
        long totalMemory = GC.GetTotalMemory();
        if (!forceFullCollection)
        {
            return totalMemory;
        }
        int remainingSteps = 20;
        long lastMemory = totalMemory;
        float num4;
        do
        {
            GC.WaitForPendingFinalizers();
            GC.Collect();
            totalMemory = lastMemory;
            lastMemory = GC.GetTotalMemory();
            num4 = (float)(lastMemory - totalMemory) / (float)totalMemory;
        }
        while (remainingSteps-- > 0 && (-0.05 >= (double)num4 || (double)num4 >= 0.05));
        
        return lastMemory;
    }
