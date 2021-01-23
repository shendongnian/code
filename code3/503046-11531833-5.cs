    if(os.QADate == null) //Could easily be os.QADate == DateTime.MinValue too, for example
    {
        SQLCommand.Parameters.Add(new OleDbParameter() { Name = "@QADATE", Value = DBNull.Value, DbType = DbType.DateTime});
    }
    else{
        SQLCommand.Parameters.Add(new OleDbParameter() { Name = "@QADATE", Value = os.QADate, DbType = DbType.DateTime});
    }
