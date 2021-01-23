    //Parent UserControl
    public partial class WebUserControlParent : System.Web.UI.UserControl
    {
        public WebUserControlChild mChildControl
        {
            get
            {
                return this.ctrlChild;
            }
            set{
               this.ctrlChild = value;
            }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
