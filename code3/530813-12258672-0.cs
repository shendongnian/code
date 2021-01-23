    OleDbConnection accessConnect = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;       Data Source=C:\ECM\ECM\ECM\ECM.mdb");
    DataTable dt = new DataTable();
    OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM ECMeasurements", accessConnect);
    
    da.Fill(dt); 
    BindingSource bs = new BindingSource();
    bs.DataSource = dt;
    dataGridView1.DataSource = bs;
