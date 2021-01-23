    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lvImages.DataSource = new List<MyImage>
                {
                    new MyImage{UserName="Deni",Photo="pic1.jpg"},
                    new MyImage{UserName="Chad",Photo="pic2.jpg"},
                    new MyImage{Photo=null},
                };
                lvImages.DataBind();
            }
        }
    }
    
    public class MyImage
    {
        public string UserName { get; set; }
        public string Photo { get; set; }
    }
