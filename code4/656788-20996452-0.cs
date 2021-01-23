    [ComVisible(true)]
    [Guid("2FFC2C20-A27B-4D67-AEA3-350223D3655F")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDataSystemInterfaceEventListener
    {
    	void OnIntializeCompleted(int status);
    	void OnTerminateCompleted(int status);
    	void OnRunCompleted(int status);
    }
    
    [ComVisible(true)]
    [Guid("B9953413-A8C9-4CE2-9263-B488CA02E7EC")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IDataSystemInterface
    {
    	void Intialize(string config);
    	void StartRun(string conditions);
    	void StopRun();
    	void Terminate();        
    
    	IDataSystemInterfaceEventListener Listener { get; set; }
    }
