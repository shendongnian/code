    public void SetState()
    {
        lock(syncObj)
        {
            state = EState.Waiting;
            stateTimer.Change(1000, Timeout.Infinite);
        }
    }
    
    public void ResetState()
    {
        lock(syncObj)
        {
            if(state != EState.Waiting)
            {
                state = EState.Off;
            }
        }
    }
    
    private void TimerResetState()
    {
        lock(syncObj)
        {
            state = EState.Off;
            stateTimer.Change(Timeout.Infinite, Timeout.Infinite);
        }
    }
