    protected void Button1_Click(object sender, EventArgs e)
    {
        OleDbConnection con= new OleDbConnection(connectionString);
        SqlDataAdapter da = new SqlDataAdapter(string.Format("SELECT * FROM {0}",DropDownList1.SelectedValue), con);
        DataSet ds = new DataSet();
        da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
        da.Fill(ds);
        GridView1.DataSource = ds.Tables[0];
        GridView1.DataBind();
        con.Close();
    }
