    string sqlcmd = "INSERT INTO signatures VALUES (@QASignature, @QADATE)"; 
    using(OleDbCommand SQLCommand = new System.Data.OleDb.OleDbCommand(sqlcmd, Connection))
    { 
        SQLCommand.Parameters.AddWithValue("@QASignature",  os.QASignature);
        SQLCommand.Parameters.Add("@QADATE", System.Data.OleDb.OleDbType.Date).Value = (os.QADate == DateTime.MinValue ? DBNull.Value:os.QADate); 
        SQLDataReader = SQLCommand.ExecuteNonQuery(); 
    } 
