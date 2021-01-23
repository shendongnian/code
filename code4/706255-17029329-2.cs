    using (var connection = Utilities.GetConnection())
    { 
        string table = Convert.ToString(txt1.Text);
        string cmb1Value = Convert.ToString(cmb1.SelectedItem);
        // Stored Procedure
        SqlCommand select = new SqlCommand("STOREDPROCEDURE", connection);
        select.Parameters.Add(new SqlParameter("@TableName", cmb1Value));
        // That's the key to let ADO.NET accept the previous CommandText as valid.
        // If you omit this the CommandText is assumed to be a SELECT/UPDATE/DELETE etc..
        select.CommandType = CommandType.StoredProcedure;  
        // Data View
        SqlDataAdapter ad= new SqlDataAdapter(select);
        DataTable dt = new DataTable();
        ad.Fill(dt); 
        BindingSource b = new BindingSource();
        b.DataSource = dt;
        dGrid.DataSource = b;
    }
