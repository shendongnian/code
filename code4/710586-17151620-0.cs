    var sqlCommand = new SqlCommand("dbo.updateclass", sqlConnection);
    sqlCommand.CommandType = CommandType.StoredProcedure;
    sqlCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = ID;
    sqlCommand.Parameters.Add(new SqlParameter("@NEWCLASS", SqlDbType.Int)).Value = NewPC;
    sqlCommand.Parameters.Add(new SqlParameter("@OLDCLASS", SqlDbType.Int)).Value = oldPC;
    cmd.Connection.Open();
    cmd.ExecuteNonQuery();
