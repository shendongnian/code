      public void Save()
        {
            SqlDataReader _dataReader;
            using (new MyConnectionManager())
            {
                _sqlCommand = new SqlCommand("SavePDFFile", MyConnectionManager.Connection);
                _sqlCommand.CommandType = CommandType.StoredProcedure;
                _sqlCommand.Parameters.Add(new SqlParameter("@UserID", this.UserID));
                _sqlCommand.Parameters.Add(new SqlParameter("@Name", this.Name));
                _sqlCommand.Parameters.Add(new SqlParameter("@Type", this.Type));
                _sqlCommand.Parameters.Add(new SqlParameter("@Length", this.Length));
                _sqlCommand.Parameters.Add(new SqlParameter("@Content", this.Content));
                _dataReader = _sqlCommand.ExecuteReader();
         
                _dataReader.Close();
            }
        } 
