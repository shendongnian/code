    void mRecipeTimer_Elapsed(object sender, ElapsedEventArgs e)
    {
        mRecipeTimer.Enabled = false; //<---- disable
    
        int sync = Interlocked.CompareExchange(ref syncPoint, 1, 0);
        if (sync == 0)
        {
            Thread.CurrentThread.Name = string.Format("timer, started at {0} ({1})", DateTime.Now, DateTime.Now.Millisecond);
            Log.Info("Recipe timer elapsed.");
            // some code
            syncPoint = 0;
        }
    
        mRecipeTimer.Enabled = true; //<---- enable
    }
