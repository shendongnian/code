    public static long GetTotalMemory(bool forceFullCollection)
    {
        long totalMemory = GC.GetTotalMemory();
        if (!forceFullCollection)
        {
            return totalMemory;
        }
        int num2 = 20;
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
        while (num2-- > 0 && (-0.05 >= (double)num4 || (double)num4 >= 0.05));
        
        return num3;
    }
