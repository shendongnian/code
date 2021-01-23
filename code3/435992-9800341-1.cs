    static void tryoledb() {
        var strAccessConn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Database1.accdb";
        string strAccessSelect = "SELECT * FROM myTest";
        DataSet myDataSet = new DataSet();
        OleDbConnection myAccessConn = null;
        myAccessConn = new OleDbConnection(strAccessConn);
        OleDbCommand myAccessCommand = new OleDbCommand(strAccessSelect, myAccessConn);
        OleDbDataAdapter myDataAdapter = new OleDbDataAdapter(myAccessCommand);
        myAccessConn.Open();
        myDataAdapter.Fill(myDataSet, "myTest");
        var mytable = myDataSet.Tables["myTest"];
        DataRowCollection dra = mytable.Rows;
        // Set the field ValueDecimal 
        dra[0][1] = 5.4;
        dra[1][1] = 5.4m;
        dra[2][1] = decimal.Parse("5.4");
        dra[3][1] = decimal.Parse("5,4");
        // Set the field ValueDouble 
        dra[0][2] = 5.4;
        dra[1][2] = 5.4m;
        dra[2][2] = double.Parse("5.4");
        dra[3][2] = double.Parse("5,4");
        var command = new OleDbCommand("UPDATE myTest SET ValueDecimal = ?, ValueDouble = ? WHERE ID = ?", myAccessConn);
        var p = command.Parameters.Add("ValueDecimal", OleDbType.Decimal); // Change to OldDbType.Double to make it work
        p.SourceColumn = "ValueDecimal";
        p.SourceVersion = DataRowVersion.Current;
        p = command.Parameters.Add("ValueDouble", OleDbType.Double);
        p.SourceColumn = "ValueDouble";
        p.SourceVersion = DataRowVersion.Current;
        p = command.Parameters.Add("ID", OleDbType.Integer);
        p.SourceColumn = "ID";
        p.SourceVersion = DataRowVersion.Original;
        myDataAdapter.UpdateCommand = command;
        myDataAdapter.Update(mytable);
        myAccessConn.Close();
    }
