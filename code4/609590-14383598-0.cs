    public string NextInstance()
    {
    	while (true)
    	{
    		// Advance this.CurrentIndex to the next location of the primary search string
    		this.SearchForNext();
    
    		// Look a little before and after the primary search string
    		this.CurrentContext = this.GetContextAtCurrentIndex();
    
    		// Primary search string found?
    		if (this.AnotherInstanceFound)
    		{
    			// If there is a valid secondary search string, is that found near the
    			// primary search string? If not, look for the next instance of the primary
    			// search string
    			if (!string.IsNullOrEmpty(this.SecondarySearchString) &&
    				!this.IsSecondaryFoundInContext())
    			{
    				continue; // Start searching again...
    			}
    			// 
    			else
    			{
    				return this.CurrentContext;
    			}
    		}
    		// No more instances of the primary search string
    		else
    		{
    			return null;
    		}
    	}
    }
