    private void AllowOtherSelectors(bool value)
    {
	    var saved = this.AllowMultiple;
		
        foreach (var c in this.Parent.Controls)
        {
		    var rgs = c as RoundGroupedSelector;
			
			if (rgs != null)
                rgs.AllowMultiple = value;
        }
	    this.AllowMultiple = saved;
	}
	
