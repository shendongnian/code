    BindingSource bs = (BindingSource )MyGridView.DataSource;
    DataTable dt= (DataTable ) bs.DataSource;
    DataSet ds = new DataSet();
    ds.Tables.Add(dt);
    ds.Tables[0].WriteXml("E:\\test2.xml"); 
