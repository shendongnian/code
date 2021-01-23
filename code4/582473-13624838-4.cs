    public partial class WebForm1 : System.Web.UI.Page
    {
        public string MyProperty { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            MyProperty = "aaaaaaaaa";
        }
    }
