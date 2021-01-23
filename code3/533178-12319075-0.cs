    public Boolean BeepInTime(Interfaces.IBeep beeper, TimeSpan beepTime) 
    {
        var h = time.GetTime();            
        if (h == beepTime)            
        {                 
            return beep.Beeping();            
        } 
                  
        return false;
    }
