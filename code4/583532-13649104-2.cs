    public class Helper
    {
    	private Page AssociatedPage;
    	
    	public Helper(Page page)
    	{
    		this.AssociatedPage = page;
    	}
    
        public void hideLinks(){
            // error is produced at the following line at the start of
            // login.aspx or registration.aspx pages.
            LinkButton profile = (LinkButton)AssociatedPage.Master.FindControl("LinkButton1");
            LinkButton logout = (LinkButton)AssociatedPage.Master.FindControl("LinkButton2");
            profile.Visible = false;
            logout.Visible = false;
        }        
    }
