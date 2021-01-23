    public class AuthorizedPage: System.Web.UI.Page
    {
        protected override void OnLoad(EventArgs e)
        {
           // ... authenticate and authorize here...
           
           // Be sure to call the base class's OnLoad method!
           base.OnLoad(e);
        }
    }
