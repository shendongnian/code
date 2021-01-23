    private System.Threading.Timer timer = new System.Threading.Timer(TimerTick, null, TimeSpan.Zero, TimeSpan.FromMinutes(5));
    
    private bool FCheckingMails = false;
    void TimerTick(object state)
    {
        if (FCheckingMails) return;
        FCheckingMails = true;
        try
        {
            //check mail here
        }
        finally
        {
            FCheckingMails = false;
        }
    }
