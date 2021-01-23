    bool pause = false;
    bool cancel = false;
    void DoWork()
    {
        try
        {
            ...
            //periodically check the flags
            if(cancel) return;
            while(paused){}; //spin on pause
            ...
        }
        finally
        {
            //cleanup operation
        }
    }
