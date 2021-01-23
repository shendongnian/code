    DataTable ParentIDs = new DataTable();
    ParentIDs.Columns.Add("ID", typeof(int));
    
    SqlConnection connection = new SqlConnection(yourConnectionInfo);
    SqlCommand command = new SqlCommand("MyStoredProc", connection);
    command.CommandType = CommandType.StoredProcedure;
    command.Parameters.Add("@ParentIDTable", SqlDbType.Structured).Value = ParentIDs;
    command.Parameters["@ParentIDTable"].TypeName = "Int32List";
