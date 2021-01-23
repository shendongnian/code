    public GetXmlFromDataSet()
    {
        DataSet myDataSet = new DataSet();
        DbDataAdapter myDataAdapter = DatabaseFactory.CreateDataAdapter();
        DbConnection DatabaseConnection = new DatabaseConnection(/*put appropriate values here*/);
        XmlTextWriter myXmlTextWriter = new XmlTextWriter(/*put appropriate values here*/)
        myDataDapter.SelectCommand = DatabaseFactory.CreateCommand();
        myDataDapter.SelectCommand.CommandType = CommandType.StoredProcedure;
        myDataAdapter.CommentText = "EXEC MyStoredProc";
        myDataAdapter.SelectCommand.Connection = DatabaseConnection;
        myDataAdapter.Fill(myDataSet);
        myDataSet.WriteXml(myXmlWriter);
    }
