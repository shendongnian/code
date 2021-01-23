    public static int GetCoreCount()
    {
        int cores = Environment.ProcessorCount;
    
        if (cores <= 2) { return 2; }
        else { return cores - 1; }
    }
