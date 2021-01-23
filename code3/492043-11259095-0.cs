    OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Pathname");
    con.Open();
    OleDbDataAdapter da = new DataAdapter(SQL command, conn);
    da.Update(dataset);
    con.Close();
