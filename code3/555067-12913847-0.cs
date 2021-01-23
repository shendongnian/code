    public class HttpsPage : Page {
    
    
    protected override void OnLoad(..)
    {
     if (Utilities.Utility.HttpsCheck)
        {
            if (!Request.IsSecureConnection)
            {
                Response.Redirect(your-url);
            }
        }
    }
    }
