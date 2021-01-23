    string connectionString= ...
    string target="jh";
    
    using (var conn=new SqlConnection(connectionString)) {
    conn.Open();
      using (var cmd=conn.CreateCommand()) {
        cmd.CommandText="select Name from Names where Name like '%'+@value+'%'";
        cmd.Parameters.AddWithValue("@value",target);
    	
    	using (var reader=cmd.ExecuteReader()) {
    		while (reader.Read()) {	
    			Console.WriteLine(reader[0]);
    		}
    	}
      
      }
    }
