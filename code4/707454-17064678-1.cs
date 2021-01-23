    // System.Web.UI.WebControls.TextBox
    public virtual string Text
    {
    	get
    	{
    		string text = (string)this.ViewState["Text"];
    		if (text != null)
    		{
    			return text;
    		}
    		return string.Empty;
    	}
    	set
    	{
    		this.ViewState["Text"] = value;
    	}
    }
