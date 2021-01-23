    //Get the data you want to process
    DataTable data = GetData();
    
    //Create new Connection
    Connection conn = Connection.CreateNew();
    
    //Open the connection
    conn.Begin()
    //Insert the data on a temporary table using the open connection
    InsertDataIntoTemporaryTable(conn, data);
    
    //Call the procedure to process the data using the same open connection
    CallProcedureToProcessData(conn);
    
    //Finish by ending the connection (everything done in the procedure will be commited)
    conn.End();
