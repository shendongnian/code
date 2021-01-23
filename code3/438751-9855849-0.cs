    [PartialCaching(0)]
    public partial class MyControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] != null)
            {            
                this.CachePolicy.Duration = TimeSpan.FromSeconds(60);
            }
        }
    }
