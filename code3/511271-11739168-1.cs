    string Sql="SELECT * FROM MYTABLE WHERE 1=0";
    string connectionstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MYDATA.MDB;"
    OleDbConnection new OleDbConnection(connectionstring);
    conn.Open();
    OleDbCommand cmd = new OleDbCommand(Sql, conn);
    OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
    DataTable table = new DataTable();
    adapter.Fill(table);
    conn.Close();
