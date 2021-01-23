    using(var connection = defs.GetConnection())
    {
        using(var cmd = new SqlCommand())
        {
            cmd.Connection = connection;
            switch(oper)
            {
                case "submit":
                     cmd.CommandText = "update DCM_Mapping_Sessions" +
                                           "set StatusID=2" +
                                           "where MappingSessionID=" + mpsid;
                case "...
            }
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch(SomeSpecificExceptionIShouldActuallyHandleHere ex)
            {
               ...
            }
        }
    }
