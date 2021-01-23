    
    /// <summary>
    /// Override the result to get the selected value in the save action
    /// </summary>
    public override ControlResult Result
    {
    	get
    	{
    		return new ControlResult(this.ControlName, this.textbox.Text, MaxLeadManagerFieldName);
    	}
    }
