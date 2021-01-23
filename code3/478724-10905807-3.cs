    pvCommand.CommandType = CommandType.StoredProcedure;
    
    pvCommand.Parameters.Clear();
    pvCommand.Parameters.Add(new SqlParameter("@ContractNumber", contractNumber));
    object uniqueId;
    int id;
        try
        {
        uniqueId = pvCommand.ExecuteScalar();
         id = Convert.ToInt32(uniqueId);
        }
        catch (Exception e)
        {
            Debug.Print("  Message: {0}", e.Message);
        }
    }
