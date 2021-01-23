    DbCommand comm = GenericDataAccess.CreateCommand();
    //Set the store Proc name 
    comm.CommandText = "AddContacts";
    DbParameter paramDetails = comm.CreateParameter();
    comm.Parameters.Add(paramDetails);
    // add other parameters ...
    foreach (var c in contacts)
    {
        // in the loop, just update parameter values and execute the command
        paramDetails.Value = c.ContactDetail;
        GenericDataAccess.ExecuteNonQuery(comm)
    }
