    using (OdbcConnection connection = new OdbcConnection(GetConnectionString()))
    {
       using (IDbCommand command = new OdbcCommand())
       {
          command.CommandText = "{ ? = CALL sp_MSnextID_DDB_NEXTID(?) }";
          command.CommandType = CommandType.StoredProcedure;
          
    
          IDbDataParameter parameter2 = command.CreateParameter();
          parameter2.DbType = DbType.Int32;
          parameter2.ParameterName = "@Return_Value";
          parameter2.Direction = ParameterDirection.ReturnValue;
          command.Parameters.Add(parameter2);
          IDbDataParameter parameter1 = command.CreateParameter();
          parameter1.DbType = DbType.String;
          parameter1.ParameterName = "@tablesequence";
          parameter1.Value = "ddb_dc_document";
          parameter1.Direction = ParameterDirection.Input;
          command.Parameters.Add(parameter1);
          
          command.Connection = connection;
          connection.Open();
          command.ExecuteNonQuery();
          IDbDataParameter o = (command.Parameters)["@Return_Value"] as IDbDataParameter;
          //Got return value from SP in o.Value
       }
    }
