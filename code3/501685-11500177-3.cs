    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            this.ddl.DataSource = new DataClassesDataContext().jobs;
            this.ddl.DataBind();
        }
    }
    protected void timer_Tick(object sender, EventArgs e)
    {
        this.grid.DataBind();
    }
