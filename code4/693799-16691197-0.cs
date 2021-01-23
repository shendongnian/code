    string ipAddress;
    public moxa_nport_5110(Delegate TriggerCallBackMethod, Delegate Callback, params object[] CtorParam)
    {
        #region Initialize
        triggerCallBackMethod = TriggerCallBackMethod;
        instanceName = (string)CtorParam[0];
        string ipAddress = (string)CtorParam[1];
    }
