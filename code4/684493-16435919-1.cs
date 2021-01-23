    private object mylock = new Object();
    public void RunThreads()
    {
        // ...
    }
    
    private void Increment()
    {
        lock (mylock)
        {
            number += number;
        }
    }
