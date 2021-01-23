    public void ThreadARunner()
    {
        lock(a)
            Monitor.Wait(a); //waits here until thread C pulses, releasing the lock on a
        lock(b)
            Monitor.Pulse(b); //wakes up thread B
    }
    public void ThreadBRunner()
    {
        lock(b)
            Monitor.Wait(b); //waits here until thread A pulses, releasing the lock on b
    }
    public void ThreadCRunner()
    {
        lock(a)
            Monitor.Pulse(a); //wakes up thread a
    }
