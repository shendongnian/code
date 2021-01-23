    const string ColumnOne = "ColumnOne";
    const string ColumnTwo = "ColumnTwo";
    var sqlCmd = new SqlCommand("select [VALUE1] as " + ColumnOne + ", [VALUE2] as " + ColumnTwo + " from table", sqlConn);
    var sqlCmdReader = sqlCmd.ExecuteReader();
    if (sqlCmdReader.Read())
		{
		var resultOne= sqlCmdReader.GetString(sqlCmdReader.GetOrdinal(ColumnOne));
        var resultTwo= sqlCmdReader.GetString(sqlCmdReader.GetOrdinal(ColumnTwo ));
    }
