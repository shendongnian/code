    OracleConnection conn= new OracleConnection("Data Source=datasrc;User=USER;Password=passwd");
    conn.Open();
    OracleTransaction tr = conn.BeginTransaction();
    OracleCommand cmd = new OracleCommand("LOCK TABLE TABLE_NAME IN EXCLUSIVE MODE",conn,tr);
    cmd.ExecuteNonQuery();
    Console.ReadLine();
    tr.Commit();
    conn.Close();
