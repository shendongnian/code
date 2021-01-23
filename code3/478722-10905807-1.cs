    pvCommand.CommandType = CommandType.StoredProcedure;
    
    pvCommand.Parameters.Clear();
    pvCommand.Parameters.Add(new SqlParameter("@ContractNumber", contractNumber));
    
        try
        {
        int uniqueId = pvCommand.ExecuteScalar();
    
        }
        catch (Exception e)
        {
            Debug.Print("  Message: {0}", e.Message);
        }
    }
