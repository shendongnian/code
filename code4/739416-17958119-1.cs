     var results = GetGuids(instId);
        foreach (var item in results)
        {
        
        }
        
        public IEnumerable<Guid> GetGuids(int id)
                {
                    using (SqlCommand _command = new SqlCommand("StoredProc"))
                    {
                        _command.Connection = new SqlConnection(conString);
                        _command.Connection.Open();
                        _command.CommandType = CommandType.StoredProcedure;
                        _command.Parameters.AddWithValue("@ItemID", id);
        
        var guids = new List<Guid>();
        
                       using (SqlDataReader reader = _command.ExecuteReader())
                       {
                         while (reader.Read()
                         {
                        guids.Add( (Guid)reader["GuidColumn"]);
                          }
                        }
                    }
                }
