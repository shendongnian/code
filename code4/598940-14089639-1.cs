    using (SqlCommand cmd = new SqlCommand("SELECT * FROM ItemShape", conn))
    {
        SqlDataAdapter dap = new SqlDataAdapter(cmd);
        DataTable tblShapes = new DataTable();
        dap.Fill(tblShapes);
        // define Display and Value members
        lbxObjects.DisplayMember = "Shape";
        lbxObjects.ValueMember = "ID";
        // set the DataSource to the DataTable 
        lbxObjects.DataSource = tblShapes;
    }
