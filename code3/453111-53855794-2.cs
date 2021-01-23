    protected virtual void New()
    {
    	// handle case when model is dirty
    	if (ModelIsDirty)
    	{
    		var args = new DiscardingChangesEventArgs();    // defaults to cancel, so someone will need to handle the event to signal discard/save
    		DiscardingChanges?.Invoke(this, args);
    		switch (args.Operation)
    		{
    			case DiscardingChangesOperation.Save:
    				if (!SaveInternal()) 
    					return;
    				break;
    			case DiscardingChangesOperation.Cancel:
    				return;
    		}
    	}
    
    	// continue with New operation
    }
    protected virtual void Delete()
    {
    	var args = new CancelEventArgs();
    	DeletingRecord?.Invoke(this, args);
    	if (args.Cancel)
    		return;
    
    	// continue delete operation
    }
