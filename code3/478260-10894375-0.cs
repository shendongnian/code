    // store sorting across postbacks in a ViewState variable
    public string SortExpression
    {
        get
        {
            if (ViewState["GridSort"]== null)
            {
                ViewState["GridSort"] = "Column1 ASC";
            }
            return ViewState["GridSort"].ToString();
        }
        set { ViewState["GridSort"] = value; }
    }
    protected void Page_load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindGrid();
        }
    }
