    [HostProtectionAttribute(SecurityAction.LinkDemand, ExternalThreading = true)]
    public virtual IAsyncResult BeginRead(
    	byte[] buffer,
    	int offset,
    	int count,
    	AsyncCallback callback,
    	Object state
    )
    
    public virtual int EndRead(
    	IAsyncResult asyncResult
    )
