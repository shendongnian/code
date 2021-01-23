    void Main()
    {
        new NoisyObject("Not finalized when /o-");
        for (;;)
        {
            // do something that will provoke the garbage collector
            AllocateSomeMemory();
        }
    }
