        int[] intarray = { 1, 2, 3, 4, 5 };  
        string[] result = intarray.Select(x=>x.ToString()).ToArray();
     
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "sp_DeleteMultipleId";
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.Add("@Id",SqlDbType.VARCHAR).Value=result ;
