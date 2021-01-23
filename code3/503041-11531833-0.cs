    string sqlcmd = "INSERT INTO signatures (QASignature, QADate) VALUES (?, ?)";
    using (System.Data.OleDb.OleDbCommand SQLCommand = new System.Data.OleDb.OleDbCommand(sqlcmd, Connection))
    {
        SQLCommand.Parameters.Add(new OleDbParameter() { Name = "QASignature", Value = os.QASignature, DbType = DbType.String});
        SQLCommand.Parameters.Add(new OleDbParameter() { Name = "QADATE", Value = os.QADate, DbType = DbType.DateTime});
        SQLDataReader = SQLCommand.ExecuteReader();
    } 
