    public async Task<int> ExecuteIntScalarAsync(string functionName, IEnumerable<MySqlParameter> parameters)
        {
        using (var con = new MySqlConnection({connectionString}))
        {
            await con.OpenAsync();
            MySqlCommand cmd = new MySqlCommand(functionName) { CommandType = System.Data.CommandType.StoredProcedure, Connection = con };
            if (parameters != null)
               foreach (var parameter in parameters)
                   cmd.Parameters.Add(parameter);
            var returnValue = new MySqlParameter("returnvalue", MySqlDbType.Int32);
            returnValue.Direction = ParameterDirection.ReturnValue;
            await cmd.ExecuteScalarAsync();
            return (int)returnValue.Value;
        }
    }
