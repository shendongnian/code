    using(System.IO.FileStream MyReadXml= new System.IO.FileStream(MyXmlFile,System.IO.FileMode.Open));
    {
        ds.ReadXml(MyReadXml);
    
        DataGrid DataGrid1 = new DataGrid();
    
        DataGrid1.DataSource = ds;
        DataGrid1.DataBind();
    }
