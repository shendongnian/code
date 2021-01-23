    using(OleDbConnection connection = new OleDbConnection("........"))
    using(OleDbCommand command = new OleDbCommand(selectString,connection))
    using(OleDbDataAdapter adapter = new OleDbDataAdapter(command))
    {
        connection.Open();
        DataSet myDataSet = new DataSet();
        adapter.Fill(myDataSet, tablename);
    }
