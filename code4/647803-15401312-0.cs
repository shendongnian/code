    private void MainClass_Load(object sender, System.EventArgs e)
    {
        string connectionString = @"Driver={MySQL};SERVER=localhost;DATABASE=NorthwindMySQL;";
    
        OdbcConnection conn= new OdbcConnection(connectionString);
        conn.Open();
    
        OdbcDataAdapter da = new OdbcDataAdapter ("SELECT CustomerID, ContactName, ContactTitle FROM Customers", conn);            
    
        DataSet ds = new DataSet("Cust");     
        da.Fill(ds, "Customers");
    
        dataGrid1.DataSource = ds.DefaultViewManager;
        conn.Close();
    }
