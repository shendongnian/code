    if !TryCreateExternalCall(callParams)
    {
      _log.Error("Unexpected exception when trying execute an external code.", ex);
      _callService.UpdateCallState(call, CallState.Disconnected, CallOutcome.Failed); 
    }
    else
    {
      throw new ExternalServiceException(???);
    }
