    var enumerator = terminalsToSync.GetEnumerator();
    if(enumerator.MoveNext())
    {
      do
      {
        //sync enumerator.Current
      } while(enumerator.MoveNext())
    }
    else
      GatewayLogAction.WriteLogInfo(Messages.NoTerminalsForSync);
    
