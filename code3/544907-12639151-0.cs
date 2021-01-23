        var dt = new DataTable();
        dt.Columns.Add("nrtest");
        dt.Columns.Add("asd");
        dt.Columns.Add("dsa");
        dt.Columns.Add("qwe");
        dt.Columns.Add("ewq");
        dt.Rows.Add("test1", "", "", "", "");
        dt.Rows.Add("test2", "", "", "", "");
        dt.Rows.Add("test3", "", "", "", "");
        mygrid.DataSource = dt;
        mygrid.DataBind();
        
 
