    public string Value
    {
    	get { return value; }
    	set
    	{
    		if (this.value != value) {
    			this.value = value;
    			this.Text = Transform(value);
    		}
    	}
    }
    
    public override string Text
    {
    	get { return base.Text; }
    	set
    	{
    		if (base.Text != value) {
    			base.Text = value;
    			this.value = TransformBack(value);
    		}
    	}
    }
