    InsertQuery = New MySqlCommand("xxxxxx")
    InsertQuery.Connection = Connection
    InsertQuery.CommandType = Data.CommandType.StoredProcedure
    InsertQuery.Parameters.AddWithValue("IN_xxx", str_xxxx)
    InsertQuery.Parameters.Add("OUT_LastID", MySqlDbType.Int32).Direction = ParameterDirection.Output
    IQ = InsertQuery.ExecuteReader()
    IQ.Read()
    LASTID = InsertQuery.Parameters("OUT_LastID").Value
