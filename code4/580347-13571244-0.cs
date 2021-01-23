    [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsValid
    {
    	get
    	{
    		if (!this._validated)
    		{
    			throw new HttpException(SR.GetString("IsValid_Cant_Be_Called"));
    		}
    		if (this._validators != null)
    		{
    			ValidatorCollection validators = this.Validators;
    			int count = validators.Count;
    			for (int i = 0; i < count; i++)
    			{
    				if (!validators[i].IsValid)
    				{
    					return false;
    				}
    			}
    		}
    		return true;
    	}
    }
