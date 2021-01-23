    protected override void OnOpening()
    {
    	base.OnOpening();
    	this.innerFactory = this.CreateFactory();
    	if (this.innerFactory == null)
    	{
    		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(SR.GetString("InnerChannelFactoryWasNotSet")));
    	}
    }
