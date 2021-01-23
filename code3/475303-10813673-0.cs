    public newManageClass()
    {
    	private oldManagedVBClass _old;
    	
    	//.ctor
    	public newManageClass()
    	{
    		_old = new oldManagedVBClass();
    	}
    	
    	public void makePanelsVisible()
    	{
    		_old.MakePanelsVisible();
    	}
    }
