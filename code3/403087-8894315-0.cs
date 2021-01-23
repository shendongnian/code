    con.Open();
    da = new System.Data.OleDb.OleDbDataAdapter();
    da.SelectCommand = new OleDbCommand("Employee", con);
    da.SelectCommand.CommandType = CommandType.TableDirect;
    da.Fill(dsl);
