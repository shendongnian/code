     public class File
     {
   
        public string Name { get; set; }
        public string Type { get; set; }
        public long Length { get; set; }
        public byte[] Content { get; set; }
  
    }
	
    public class User
    {
		public int UserID {get; set;}
		public string name {get; set;}
		/**/
		
		public file file {get; set;}
		/**/
		
		public void SaveFile()
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
	  public void LoadFile()
        { 
            SqlDataReader _dataReader;
            using (new MyConnectionManager())
            {
                _sqlCommand = new SqlCommand("GetPDFFIle", MyConnectionManager.Connection);
                _sqlCommand.CommandType = CommandType.StoredProcedure;
                _sqlCommand.Parameters.Add(new SqlParameter("@UserID", this.IDEnsayo));
                _dataReader = _sqlCommand.ExecuteReader();
                if (_dataReader.HasRows)
                {
                    _dataReader.Read();
                    this.Archivo.Name = (string)_dataReader["Name"];
                    this.Archivo.Type = (string)_dataReader["Type"];
                    this.Archivo.Length = (int)_dataReader["Length"];
                    this.Archivo.Content = (byte[])_dataReader["Content"];
                
                }
                _dataReader.Close();
            }
        }
	  
    }
