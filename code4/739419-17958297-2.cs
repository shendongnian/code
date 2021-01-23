    public IEnumerable<Guid> GetGuids(int id)
    {
        using (SqlCommand _command = new SqlCommand("StoredProc"))
        {
            _command.Connection = new SqlConnection(conString);
            _command.Connection.Open();
            _command.CommandType = CommandType.StoredProcedure;
            _command.Parameters.Add("@ItemID", SqlDbType.Int).Value =  id;
                return _command.ExecuteReader()
                      .Cast<DbDataRecord>()
                      .Select(r => (Guid)r["GuidColumn"]);
        }
    } 
