    SqlCommand ImageCommand = new SqlCommand("", (SqlConnection)connection, (SqlTransaction)Transaction);
        
    ImageCommand.CommandText = string.Format(@"Update xdpath set content = @ByteArray where dpath = '{0}'",file.Key);
    
    ImageCommand.Parameters.Add("@ByteArray", SqlDbType.Image).Value = (object)encodedBytes ?? DBNull.Value;
