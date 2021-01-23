        DataTable dt = new DataTable();
        dt.Columns.Add(new DataColumn("Action", typeof(bool)));            
        dt.Rows.Add(0);
        dt.Rows.Add(1);
        GridView1.DataSource = dt;
        GridView1.DataBind();  
