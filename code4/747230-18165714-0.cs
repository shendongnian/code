    protected void Page_Load(object sender, EventArgs e)
    {
        if(ViewState["gvCommissions"] != null) dt = (DataTable)ViewState["gvCommissions"];
        if (!Page.IsPostBack)
        {
            GridViewStructure();
            AddNewRow();
        }
        else
        {
            dt = (DataTable)ViewState["gvCommissions"];
        }
    
        ViewState["gvCommissions"] = dt;  
    }
