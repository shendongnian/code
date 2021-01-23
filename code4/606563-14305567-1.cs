    public DataSet CreateCmdsAndUpdate(DataSet myDataSet,string myConnection,string mySelectQuery,string myTableName) 
    {
        OleDbConnection myConn = new OleDbConnection(myConnection);
        OleDbDataAdapter myDataAdapter = new OleDbDataAdapter();
        myDataAdapter.SelectCommand = new OleDbCommand(mySelectQuery, myConn);
        OleDbCommandBuilder custCB = new OleDbCommandBuilder(myDataAdapter);
    
        myConn.Open();
    
        DataSet custDS = new DataSet();
        myDataAdapter.Fill(custDS);
    
        //code to modify data in dataset here
    
        //Without the OleDbCommandBuilder this line would fail
        myDataAdapter.Update(custDS);
    
        myConn.Close();
    
        return custDS;
     }
