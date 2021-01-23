    public virtual void Dispose()
    {
    	if (this.Site != null)
    	{
    		IContainer container = (IContainer)this.Site.GetService(typeof(IContainer));
    		if (container != null)
    		{
    			container.Remove(this);
    			EventHandler eventHandler = this.Events[Control.EventDisposed] as EventHandler;
    			if (eventHandler != null)
    			{
    				eventHandler(this, EventArgs.Empty);
    			}
    		}
    	}
    	if (this._occasionalFields != null)
    	{
    		this._occasionalFields.Dispose();
    	}
    	if (this._events != null)
    	{
    		this._events.Dispose();
    		this._events = null;
    	}
    }
