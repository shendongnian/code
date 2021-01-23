    System.Data.OleDb.OleDbConnection Cn = new System.Data.OleDb.OleDbConnection();
    Cn.ConnectionString = StrConn;
    System.Data.OleDb.OleDbDataAdapter Da = new System.Data.OleDb.OleDbDataAdapter
    (MySQLSelect, Cn);
    Cn.Open();
       Da.Fill(Items);
    Cn.Close();
    </pre>
