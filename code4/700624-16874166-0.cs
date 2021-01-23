    public class PageBase :System.Web.UI.Page
    {
    	public PageBase ()
    	{
    		//
    		// TODO: Add constructor logic here
    		//
    	}
        protected override void OnLoad(System.EventArgs e)
        {
            CheckSecurity();//any function you want to call before 
            base.OnLoad(e);
        }
    
        public virtual void CheckSecurity()
        {
            //your logic here
        }
    }
