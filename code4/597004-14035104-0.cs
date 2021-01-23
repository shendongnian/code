    private long SingleVariable = 0;
    public void MultiThreadedMethod()
    {
       Interlocked.Increment(SingleVariable);
    }
