    OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\abdozezo\Documents\Database10.accdb");
    string query = "SELECT *  FROM   Table1";
    OleDbCommand cmd = new OleDbCommand(query, con);
    OleDbDataAdapter adp = new OleDbDataAdapter(cmd);
    DataTable dt = new DataTable();
    adp.Fill(dt);
    CrystalReport1 cr1 = new CrystalReport1();
    cr1.SetDataSource(dt);
    // cr1.Load(@"CrystalReport1.rpt"); for dire`enter code here`ct upload 
    viewer.ViewerCore.ReportSource = cr1;//viewer is crystal report
