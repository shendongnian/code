    public partial class Page1 : BasePage
    {
    }
    public partial class Page2 : BasePage
    {
      protected void Page_Load(object sender, EventArgs e)
      {
            if(IsLoggedIn())
            {
            }
      }   
    }
