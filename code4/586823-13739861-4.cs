    #region IMessageFilter Members
    
            int ExcelAddinMessageFilter.IMessageFilter.
                HandleInComingCall(uint dwCallType, IntPtr htaskCaller, uint dwTickCount, ExcelAddinMessageFilter.INTERFACEINFO[] lpInterfaceInfo)
            {
                // We're the client, so we won't get HandleInComingCall calls.
                return 1;
            }
    
            int ExcelAddinMessageFilter.IMessageFilter.
    		RetryRejectedCall(IntPtr htaskCallee, uint dwTickCount, uint dwRejectType)
            {
                // The client will get RetryRejectedCall calls when the main Excel
                // thread is blocked. We can handle this by attempting to retry
                // the operation. This will continue to fail so long as Excel is 
                // blocked.
                // As an alternative to simply retrying, we could put up
                // a dialog telling the user to close the other dialog (and the
                // new one) in order to continue - or to tell us if they want to
                // abandon this call
                // Expected return values:
                // -1: The call should be canceled. COM then returns RPC_E_CALL_REJECTED from the original method call.
                // Value >= 0 and <100: The call is to be retried immediately.
                // Value >= 100: COM will wait for this many milliseconds and then retry the call.
                return 1;
            }
    
            int ExcelAddinMessageFilter.IMessageFilter.
                MessagePending(IntPtr htaskCallee, uint dwTickCount, uint dwPendingType)
            {
                return 1;
            }
    
            #endregion
