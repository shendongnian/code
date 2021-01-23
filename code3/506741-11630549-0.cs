    public override void Uninstall(IDictionary savedState)
    {
        if (Condition)
        {
            throw new InstallException("blah blah");
            // What ever you want to do after
        }
        else
        {
            base.Uninstall(savedState);
    	}    			
    }
