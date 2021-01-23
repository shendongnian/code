    // DATABASE (Local): Formulate the SQL command.
    String strSqlCommand = "SELECT * FROM tblTest ORDER BY IdPrimary ASC;";
    SQLiteCommand oLocalCommand = new SQLiteCommand(strSqlCommand, ClassEngine.Connection);
    // DATABASE (Local): Get the data records.
    SQLiteDataAdapter oLocalAdapter = new SQLiteDataAdapter(oLocalCommand);
    DataSet oLocalSet = new DataSet();
    oLocalAdapter.Fill(oLocalSet, "tblTest");
    // 
    SQLiteCommandBuilder oBuilder = new SQLiteCommandBuilder(oLocalAdapter);
    // Try to write to some changes.
    String strValue = oLocalSet.Tables[0].Rows[0][8].ToString();
    oLocalSet.Tables[0].Rows[0][8] = 9;
    strValue = oLocalSet.Tables[0].Rows[0][8].ToString();
    oLocalAdapter.UpdateCommand = oBuilder.GetUpdateCommand();
    oLocalAdapter.Update(oLocalSet.Tables[0]);
    // Clean up.
    oLocalSet.Dispose();
    oLocalAdapter.Dispose();
    oLocalCommand.Dispose();
    oLocalCommand = null;
