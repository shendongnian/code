      protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<Data> DataList = new List<Data>() { new Data { id = 1, id2 = 2 }, new Data { id = 3, id2 = 4 } };
            GridView1.DataSource = DataList;
            GridView1.DataBind();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        GridViewRow row = (GridViewRow ) btn.NamingContainer;
        Label slNoLabel = (Label) row.FindControl("slNoLabel");
        // function to get data based on label vlue
        GridView2.DataSource=GetData(slNoLabel.Text);
        GridView2.DataBind();
    }
    DataTable GetData(string value)
    {
    DataTable tbl = new DataTable ();
        //   Calling DB 
        return tbl;
        }
    }
    
    public class Data
    {
        public int id { get; set; }
        public int id2 { get; set; }
    }
