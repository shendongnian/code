    public partial class _Default : System.Web.UI.Page
    {
       NameDB Names;//Creating Object
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Names = new NameDB();//Instantiation
            Names.Add("dss");
    
            GridView1.DataSource = Names.GetName();
            GridView1.DataBind();
        }
    }
