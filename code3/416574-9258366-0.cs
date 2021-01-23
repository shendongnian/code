    var terminalsToSync = TerminalAction.GetAllTerminals().ToList();
    
    if(terminalsToSync.Any())
        SyncTerminals(terminalsToSync);
    else
        GatewayLogAction.WriteLogInfo(Messages.NoTerminalsForSync);
