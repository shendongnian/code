    public partial class _Default : System.Web.UI.Page
    {
        public string hello {get;set;}
        protected void Page_Load(object sender, EventArgs e)
        {
            hello = "hello world";
        }
    }
