    public Boolean BeepInTime(Interfaces.IDateTime time,TimeSpan beepTime, Interfaces.IBeep beep) 
    { 
        var h = time.GetTime(); 
        if (h == beepTime) 
        { 
            return beep.Beeping(); 
        } 
        else 
        { 
            return false; 
        } 
       } 
