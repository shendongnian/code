    public class BasePage : System.Web.UI.Page
    {
      protected override void OnPreInit(EventArgs e)
      {
           base.OnPreInit(e);
           Page.Theme = //Your theme;
      }
    }
