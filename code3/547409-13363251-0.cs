    protected void sqlQuery(Control controlName, String query) {
        // cast the control to the base class
        var controlWithDataSource = controlName as BaseDataBoundControl;
        if (controlWithDataSource == null)
            throw new ArgumentException("Control does not inherit BaseDataBoundControl.");
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
    
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["SqlConn"].ToString();
        cmd.Connection = conn;
    
        try {
            cmd.CommandText = query;
    
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
    
            adapter.Fill(dt);
            // here reference the new control
            controlName.DataSource = dt;
            controlName.DataBind();
    
        } catch (Exception error) {
            Label1.Text = "Error!<br/>" + error;
        }
    }
