    OleDbConnection DBCon = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=(k:\mydatabases\mydatabase.mdb");
    DBCon.Open();  
    // Create a select Command - you need System.Data.OleDb and System.Data for this
    OleDbCommand selectCommand = new OleDbCommand();
    // define the CommandText with two parameters @Filter1 and @Filter2
    selectCommand.CommandText = "SELECT * FROM Cards WHERE Name like @Filter1 and Expansion like @Filter2";
    selectCommand.Connection = DBCon;
    // Create two string / VarChar Parameters - 
    // the following is a standard I commonly use 
    // for string/varchar; you might also use OleDbType.NVarChar
    OleDbParameter param01 = new OleDbParameter();
    param01.ParameterName = "Filter1";
    param01.DbType = DbType.AnsiString;
    param01.OleDbType = OleDbType.VarChar;
    param01.SourceVersion = DataRowVersion.Current;
    param01.SourceColumn = "Name";
    // provide them with values - I used text boxes for input
    // use '%' for like statement - if no parameter provided use single '%' only
    if (txtFilter1.Text.ToString().Equals(""))
    {
        param01.Value = '%';
    }
    else
    { 
        param01.Value = '%' + txtFilter1.Text.ToString() + '%'; 
    }
    // add the parameter to the SelectCommand
    selectCommand.Parameters.Add(param01);
    // same goes for the second parameter
    OleDbParameter param02 = new OleDbParameter();
    param02.ParameterName = "Filter2";
    param02.DbType = DbType.AnsiString;
    param02.OleDbType = OleDbType.VarChar;
    param02.SourceVersion = DataRowVersion.Current;
    param02.SourceColumn = "Expansion";
    if (txtFilter2.Text.ToString().Equals(""))
    {
        param02.Value = '%';
    }
        else
    {
        param02.Value = '%' + txtFilter2.Text.ToString() + '%';
    }
    selectCommand.Parameters.Add(param02);
    OleDbDataAdapter CardDA = new OleDbDataAdapter();
    // tell the DataAdapter to use a SelectCommand
    CardDA.SelectCommand = selectCommand;
    CardDA.GetFillParameters();   // actually not sure if you need this but does no harm either
    DataSet CardDS = new DataSet();
    CardDA.Fill(CardDS, "TargetTable");
    DBCon.Close();
    foreach(DataRow row in CardDS.Tables["TargetTable"].Rows)
    {
        // do something ;
    }
