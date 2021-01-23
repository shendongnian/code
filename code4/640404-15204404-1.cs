    protected void bindToList(object sender, EventArgs e)
    {
        var datasource = GridView1.DataSource as List<Customers>;
        if ( !IsPostBack )
        {
            DropDownList ddl = new DropDownList();
            ddl.DataTextField = "Name";
            ddl.DataValueField = "Id";
            ddl.DataSource = datasource;
            ddl.DataBind();
            ddl.SelectedValue = list.Find( o => o.Selected == true ).Id.ToString();
        }
    }
