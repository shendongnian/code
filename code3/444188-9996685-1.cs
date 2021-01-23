    public void UpdatePage(LandingPage update)
    {
    	var pageToUpdate = this.Pages.Where( p => P.Id == update.Id ).SingleOrDefault();
        if( pageToUpdate != null )
        {  	
    	   // update all properties of old page with new values
    	   pageToUpdate.Title = update.Title; // for any property of Page
        }
    }
