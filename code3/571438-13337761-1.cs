    void AnalogPage_OnLoaded( ... )
    {
        StaticTimer.Tick += someEventHandler;
    }
    void someEventHandler(DateTime time)
    {
        if(thisIsCurrentPage)
        {
            clock.Update(time);
        }
    }
