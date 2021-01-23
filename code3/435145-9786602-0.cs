     protected override OnLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Ddl.DataSource = new DataSource();
                DdlIssues.DataBind();
            }
        }
