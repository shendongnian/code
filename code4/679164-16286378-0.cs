     string connectionString = @"Provider=VFPOLEDB.1;Data Source=c:\foxpro"; 
    
        using (OleDbConnection connection = new OleDbConnection(connectionString)) 
        { 
            using (OleDbCommand scriptCommand = connection.CreateCommand()) 
            { 
                connection.Open();
    
                string vfpScript = @"SET EXCLUSIVE ON
                                    USE table
                                    DELETE ALL
                                    PACK"; 
    
                scriptCommand.CommandType = CommandType.StoredProcedure; 
                scriptCommand.CommandText = "ExecScript"; 
                scriptCommand.Parameters.Add("myScript", OleDbType.Char).Value = vfpScript; 
                scriptCommand.ExecuteNonQuery(); 
            } 
        } 
