    public void UpdateClock()
    {
        ...
    }
    
    private void MT_TimerTick(object source, ElapsedEventArgs e)
    {
        if (InvokeRequired) 
        { 
            Invoke(new Action<object, ElapsedEventArgs>(TimerTick), source, e); 
        }
        else
        {
            UpdateClock();
        }
    }
