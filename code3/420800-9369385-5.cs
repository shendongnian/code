    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Image1.ImageUrl = ImageUrl;
        }
        [Editor(typeof(IconUrlEditor), typeof(UITypeEditor)), UrlProperty("*.ico")]
        public virtual string ImageUrl { get; set; }
    }
