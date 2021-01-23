    public IEnumerable<T> Select<T>(string storedProcName, object param) {
        IEnumerable<T> results;
    
        using(var connection = new SqlConnection(_connectionString) {
            results = connection.Query<T>(storedProcName, param, commandType: CommandType.StoredProcedure);
        }
    
        return results;
    }
