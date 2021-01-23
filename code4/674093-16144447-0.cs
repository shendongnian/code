    public abstract class SitePage : Page
    {
        sealed protected void Page_Load(object sender, EventArgs e)
        {
            // common logic here
            Page_LoadImpl(sender, e);
        }
    
        protected abstract void Page_LoadImpl(object sender, EventArgs e);
    }
