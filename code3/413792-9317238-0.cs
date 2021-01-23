    try {
        WaitHandle handle = BackgroundProcess.BeginStart();
        if ( !handle.WaitOne( Timeout ) ) {
            . . .
           return false;
        }
        
        List<WaitHandle> waitHandles = new List<WaitHandle>();
        foreach ( Module module in BackgroundProcess.Transit.SubModules ) {
            WaitHandle waitHandle = module.GetWaitHandleForState( Module.States.Running );
            waitHandles.Add( waitHandle );
        }
        
        if ( !WaitHandle.WaitAll( waitHandles.ToArray(), Timeout ) ) {
            . . . 
            return false;
        }
        
        // If we get here, everything is communicating properly.
        . . .
    } catch ( Exception ex ) {
        . . .
        return false;
    }
    
    return true;
