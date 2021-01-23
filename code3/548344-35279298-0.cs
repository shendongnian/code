    UInt16[] availableRequestedStates = { 2, 3, 4, 6, 7, 8, 9, 10, 11 };
    compSystem["AvailableRequestedStates"] = availableRequestedStates;
    compSystem.Put();
    ManagementBaseObject inParams = compSystem.GetMethodParameters("RequestStateChange");
    inParams["RequestedState"] = 2;
    ManagementBaseObject result = compSystem.InvokeMethod("RequestStateChange", inParams, null);
