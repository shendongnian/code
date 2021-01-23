    private readonly Func<Subcontractor, bool> _pred;
    
    public Subcontractor()
    {
    	_pred = x => x.ApplicationFormReturned == null || x.ApplicationFormReturned < this.ApplicationFormReturned;
    }
    
    private void ApplicationFormReturnedCheck( ref IList<Subcontractor> list )
    {
    	if( this.ApplicationFormNotReturnedFlag == true && this.ApplicationFormReturned != null )
    	{
    		list = list.Where( _pred ).ToList();
    	}
    	else if( this.ApplicationFormNotReturnedFlag == true )
    	{
    		list = list.Where( x => x.ApplicationFormReturned == null ).ToList();
    	}
    	else if( this.ApplicationFormReturned != null )
    	{
    		list = list.Where( x => x.ApplicationFormReturned < this.ApplicationFormReturned ).ToList();
    	}
    }
