    public partial class _Default : System.Web.UI.Page, IExport
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UC11.MyExport = this;
            //UC11 will be whatever name of your usercontrol
        }
    
        public void Export()
        {
            //your export code
        }
    }
