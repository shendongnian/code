        //Your data source (just example). 
        DataTable dataSource = new DataTable();
        dataSource.Columns.Add("col1");
        dataSource.Columns.Add("col2");
        dataSource.Columns.Add("col3");
        dataSource.Columns.Add("col4");
        dataSource.Columns.Add("col5"); 
        dataSource.Columns.Add("col6");
        dataSource.Columns.Add("col7");
        dataSource.Columns.Add("col8");
        dataSource.Columns.Add("col9");
        dataSource.Columns.Add("col10");
        dataSource.Columns.Add("col11");
        // Add new row to the data source directly instead of grid control
        dataSource.Rows.Add(new string[]
                                {
                                    "0", "1", "hesab_nomresi", "soyad", "ad", "ataadi", "vesiqe", "teskilat_kodu",
                                    "tevellud", "nomre", "cins"
                                });
        kartsifarishiGridView.DataSource = dataSource;
        kartsifarishiGridView.DataBind();
