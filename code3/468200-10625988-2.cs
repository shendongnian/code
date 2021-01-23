    public class AuthorizedPage: System.Web.UI.Page
    {
        protected override void OnLoad(EventArgs e)
        {
           // ... authorization logic here...
           
           // Be sure to call the base class's OnLoad method!
           base.OnLoad(e);
        }
    }
