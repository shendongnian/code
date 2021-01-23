    System.Data.DataTable t = new System.Data.DataTable;
    System.Data.SqlClient.SqlDataAdapter ad = new System.Data.DataAdapter(sql, connectionstring);
    ad.Fill(t);
    
    MyUserControl myControl= new MyUserControl();
    myControl.BindData(t);
