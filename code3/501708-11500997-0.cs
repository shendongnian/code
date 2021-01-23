    byte[] imageData = FileUpload1.FileBytes;
    OracleCommand cmd = new OracleCommand("INSERT INTO IMAGES(PARENT_ID, IMAGE_DATA) VALUES(:1, :2)", connection);
    cmd.Parameters.Add("1", OracleDbType.Int32, parentID, ParameterDirection.Input);
    cmd.Parameters.Add("2", OracleDbType.Blob, imageData, ParameterDirection.Input);
  
    cmd.ExecuteNonQuery();
