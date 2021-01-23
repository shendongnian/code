    var sql = "Execute User_Insert @EmailAddress, @Id = @Id OUTPUT";
    var _params = new DynamicParameters();
    _params.Add("EmailAddress", user.EmailAddress);
    _params.Add("Id", dbType: DbType.Int64, direction: ParameterDirection.Output);
    
    using (var connection = new SqlConnection(ConnectionString)) {
    	connection.Open();
    	using (var transaction = connection.BeginTransaction()) {
    		var result = SqlMapper.Execute(connection, sql, param, transaction);
    		transaction.Commit();
    	}
    }    
    var id = _params.Get<long>("Id");
 
