    protected void Page_Load(object sender, EventArgs e)
    {
    if (!IsPostBack)
    ViewState["Count"] = 0;
    }
    
    protected void btnclick_Click(object sender, EventArgs e)
    {
    ViewState["count"] = Convert.ToInt32(ViewState["count"]) + 1;
    btnclick.Text = ViewState["count"].ToString();
    }
