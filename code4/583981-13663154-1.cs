    protected void Page_Load(Object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
             DataTable table = (DataTable) Session["TblIzposoje"];
             GridView1.DataSource = table;
             GridView1.DataBind();
        }
    }
