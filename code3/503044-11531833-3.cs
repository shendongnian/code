    if(os.QADate == null)
    {
        SQLCommand.Parameters.Add(new OleDbParameter() { Name = "@QADATE", Value = DBNull.Value, DbType = DbType.DateTime});
    }
    else{
        SQLCommand.Parameters.Add(new OleDbParameter() { Name = "@QADATE", Value = os.QADate, DbType = DbType.DateTime});
    }
