    using System.Data;
    using System.Data.OleDb;
    
    public class YourClass
    {
       public DataTable GetYourData()
       {
          DataTable YourResultSet = new DataTable();
          OleDbConnection yourConnectionHandler = new OleDbConnection(
              "Provider=VFPOLEDB.1;Data Source=C:\\SomePath\\;" );
    
          // if including the full dbc (database container) reference, just tack that on
    //      OleDbConnection yourConnectionHandler = new OleDbConnection(
    //          "Provider=VFPOLEDB.1;Data Source=C:\\SomePath\\NameOfYour.dbc;" );
    
          // Open the connection, and if open successfully, you can try to query it
          yourConnectionHandler.Open();
          if( yourConnectionHandler.State == ConnectionState.Open )
          {
             OleDbDataAdapter DA = new OleDbDataAdapter();
             string mySQL = "select A1.*, B1.* "
                         + " from FirstTable A1 "
                         + "      join SecondTable B1 "
                         + "         on A1.SomeKey = B1.SomeKey "
                         + " where A1.WhateverCondition ";  // blah blah...
             OleDbCommand MyQuery = new OleDbCommand( mySQL, yourConnectionHandle );
             DA.Fill( YourResultSet );
             yourConnectionHandle.Close();
          }
          return YourResultSet;
       }
    }
