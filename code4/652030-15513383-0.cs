    void LoadListView() 
    { 
        DataSet ds = new DataSet(); 
        System.Data.OleDb.OleDbConnection con = 
            new System.Data.OleDb.OleDbConnection(@"Provider=Microsoft.Jet.OleDb.4.0;Data Source=C:\accessItems.mdb;");
        System.Data.OleDb.OleDbDataAdapter adpt = 
            new System.Data.OleDb.OleDbDataAdapter("select * from Items", con); 
        adpt.Fill(ds); 
        DataTable table = ds.Tables[0]; 
        this.listView1.Items.Clear(); 
        foreach(DataRow r in table.Rows) 
            this.listView1.Items.Add(
                new ListViewItem(r["Value"].ToString()));//value is the field of name value 
    } 
