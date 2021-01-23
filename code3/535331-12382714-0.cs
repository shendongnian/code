    SqlConnection conn = new SqlConnection();
    SqlTransaction trans = conn.BeginTransaction();
    try
    {
       using (SqlCommand cmd = new SqlCommand("insert into Test (Id,Name) values(@iD, @Name)", conn, trans))
       {
          cmd.CommandType = CommandType.Text;
          cmd.AddParameter(SqlDbType.UniqueIdentifier, ParameterDirection.Input, "@iD", ID);
          cmd.AddParameter(SqlDbType.VarChar, ParameterDirection.Input, "@Name", Name);
   
          cmd.ExecuteNonQuery();
       }
    
       conn.CommitTransaction(trans);
    }
    catch (Exception ex)
    {
       conn.RollbackTransaction(trans);
       throw ex;
    }
