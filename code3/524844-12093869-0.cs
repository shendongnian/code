    protected void Page_Load(object sender, EventArgs e)
    {
            
            if (!IsPostBack)
            {
                ddlErreur.DataSource = ...;
                ddlErreur.DataTextField = ...;
                ddlErreur.DataBind();
            }
    }
