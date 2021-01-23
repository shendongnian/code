    protected internal override void OnPreRender(EventArgs e)
    {
    	base.OnPreRender(e);
    	bool autoPostBack = this.AutoPostBack;
    	if (this.Page != null && base.IsEnabled)
    	{
    		this.Page.RegisterRequiresPostBack(this);
    		if (autoPostBack)
    		{
    			this.Page.RegisterPostBackScript();
    			this.Page.RegisterFocusScript();
    			if (this.CausesValidation && this.Page.GetValidators(this.ValidationGroup).Count > 0)
    			{
    				this.Page.RegisterWebFormsScript();
    			}
    		}
    	}
    	if (!this.SaveCheckedViewState(autoPostBack))
    	{
    		this.ViewState.SetItemDirty("Checked", false);
    		if (this.Page != null && base.IsEnabled)
    		{
    			this.Page.RegisterEnabledControl(this);
    		}
    	}
    }
