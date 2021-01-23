    protected void Page_Load(Object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
             GridView1.DataSource = getSource();
             GridView1.DataBind();
        }
    }
