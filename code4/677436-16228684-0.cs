    OleDbConnection conn = new OleDbConnection();
    conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + @"data source=C:\Users\sy\Visual Studio 2008\Projects\demo\demo\CE_Database.mdb;";
    conn.Open();
    string[][] allData = [[1,'a'],[2,'b'],[3,'c']]
    foreach (string[] individualData in allData)
    {
        OleDbCommand command = new OleDbCommand()
        {
            Connection = conn,
            CommandText = string.Format(@"insert into CETable(JobCode,JobName) Values({0}, {1});", individualData[0], individualData[1])";
        };
        command.ExecuteNonQuery();
    }
    conn.Close();
