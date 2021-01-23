    public partial class _Default : System.Web.UI.Page
    {
        public string Hello { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Hello = "hello world";
        }
    }
