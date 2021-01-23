    private object sync = new object():
    private bool running = false;
    
    private void Run()
    {
        running = true;
        while(true)
        {
            try
            {
                lock(sync)
                {
                    if(!running)
                    {
                        break;
                    }
                }
                
                BlockingFunction();
            }
            catch(ThreadInterruptedException)
            {
                break;
            }
        }
    }
    
    public void Stop()
    {
        lock(sync)
        {
            running = false;
        }
    }
