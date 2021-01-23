    using (PsqlConnection conn = new PsqlConnection(cs))
        {
            PsqlCommand locationCmd = new PsqlCommand();
            PsqlParameter dbParam = new PsqlParameter();
            PsqlParameter tableParam = new PsqlParameter();
            PsqlParameter returnParam = new PsqlParameter();
            returnParam.Direction = ParameterDirection.ReturnValue;
            locationCmd.CommandText = "psp_columns";
            locationCmd.Connection = conn;
            locationCmd.CommandType = CommandType.StoredProcedure;
    
            locationCmd.Parameters.Add(dbParam).Value = ""; //might need two single quotes ('')
            locationCmd.Parameters.Add(tableParam).Value = table;
            locationCmd.Parameters.Add(returnParam);
            conn.Open();
            locationCmd.ExecuteNonQuery();
    
        }
