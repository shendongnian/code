    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public SetterBaseCollection Setters
    {
    	get
    	{
    		base.VerifyAccess();
    		if (this._setters == null)
    		{
    			this._setters = new SetterBaseCollection();
    			if (this._sealed)
    			{
    				this._setters.Seal();
    			}
    		}
    		return this._setters;
    	}
    }
