    public partial class Sample1 : System.Web.UI.Page
    {
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)  
        {
     
        SourceDataContext db = new SourceDataContext();
    
        GridView1.DataSource = from q in db.Cust
                               orderby q.ID
                               select q;
        GridView1.DataBind();
       }
    }
    
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
    
        
    }
    protected void button1_Click(object sender, EventArgs e)
    {
        string client = TextBox1.Text;
    
        SourceDataContext db = new SourceDataContext();
    
        GridView1.DataSource = from q in db.Cust
                               where q.Client_Name == client
                               orderby q.ID
                               select q;
        GridView1.DataBind();
    
    }
    }
