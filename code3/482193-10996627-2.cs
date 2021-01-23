            DbParameter param1 = com.CreateParameter(); 
            param1.ParameterName = "@nume"; 
            param1.Value = nume; 
            param1.DbType = DbType.String; 
            param1.Size = 200; 
            com.Parameters.Add(param1); 
 
            DbParameter param2 = com.CreateParameter(); 
            param2.ParameterName = "@datapubl"; 
            param2.Value = datapubl; 
            param2.DbType = DbType.DateTime; 
            com.Parameters.Add(param2); 
