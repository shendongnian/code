    const int SmartRestart = 8;
    
    ...
    
    //APPLICATION TO SEND COMMAND
    service.ExecuteCommand(SmartRestart);
    
    ...
    
    //SERVICE
    protected override void OnCustomCommand(int command)
    {
        if (command == SmartRestart)
        {
            // ...
        }
    }
