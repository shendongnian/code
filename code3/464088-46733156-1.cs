    void ConsumeSample(ISample sample)
    {
        // INCORRECT CODE!
        // It is a developer mistake to write “using” in consumer code.
        // “using” should only be used by the code that is managing the lifetime.
        using (sample)
        {
            sample.DoSomething();
        }
        // CORRECT CODE
        sample.DoSomething();
    }
    async Task ManageObjectLifetimesAsync()
    {
        SampleB sampleB = new SampleB();
        using (SampleA sampleA = new SampleA())
        {
            DoSomething(sampleA);
            DoSomething(sampleB);
            DoSomething(sampleA);
        }
    
        DoSomething(sampleB);
    
        // In the future you may have an implementation of ISample
        // which requires a completely different type of lifetime
        // management than IDisposable:
        SampleC = new SampleC();
        try
        {
            DoSomething(sampleC);
        }
        finally
        {
            sampleC.Complete();
            await sampleC.Completion;
        }
    }
    
    class SampleC : ISample
    {
        public void Complete();
        public Task Completion { get; }
    }
