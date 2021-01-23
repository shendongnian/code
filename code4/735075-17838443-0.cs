    public string CommandArgument
    {
    	get
    	{
    		string text = (string)this.ViewState["CommandArgument"];
    		if (text != null)
    		{
    			return text;
    		}
    		return string.Empty;
    	}
    	set
    	{
    		this.ViewState["CommandArgument"] = value;
    	}
    }
