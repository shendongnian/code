    public virtual string Message
    {
    	[__DynamicallyInvokable]
    	get
    	{
    		if (this._message == null)
    		{
    			if (this._className == null)
    			{
    				this._className = this.GetClassName();
    			}
    			return Environment.GetRuntimeResourceString("Exception_WasThrown", new object[]
    			{
    				this._className
    			});
    		}
    		return this._message;
    	}
    }
