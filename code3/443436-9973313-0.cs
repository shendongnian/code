    try
    {
       externalService.CreateCall(callParams);
    }
    catch (Exception ex)
    {
       _log.Error("Unexpected exception when trying execute an external code.", ex);
       try
       {
           _callService.UpdateCallState(call, CallState.Disconnected, CallOutcome.Failed);
       }
       catch(Exception updateEx)
       {
           // do something here, don't just swallow the exception
       }
       throw; // this still rethrows the original exception
    }
