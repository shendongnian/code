    using mymachine\me True Negotiate
    mymachine\me,True,Negotiate
    
    setting svc.ClientCredentials.Windows.ClientCredential to null...
    mymachine\me,True,Negotiate
    
    using NT AUTHORITY\ANONYMOUS LOGON False
    The communication object, System.ServiceModel.Channels.ServiceChannel, cannot be
     used for communication because it is in the Faulted state.
    
    Server stack trace:
       at System.ServiceModel.Channels.CommunicationObject.Close(TimeSpan timeout)
    
    Exception rethrown at [0]:
       at System.Runtime.Remoting.Proxies.RealProxy.HandleReturnMessage(IMessage req
    Msg, IMessage retMsg)
       at System.Runtime.Remoting.Proxies.RealProxy.PrivateInvoke(MessageData& msgDa
    ta, Int32 type)
       at System.ServiceModel.ICommunicationObject.Close(TimeSpan timeout)
       at System.ServiceModel.ClientBase`1.System.ServiceModel.ICommunicationObject.
    Close(TimeSpan timeout)
       at System.ServiceModel.ClientBase`1.Close()
       at System.ServiceModel.ClientBase`1.System.IDisposable.Dispose()
       at TestClient.Program.MakeRequest()
