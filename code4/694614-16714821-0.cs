    foreach (HttpPostedFile upFile in FileUpload1.PostedFiles)
    {
        SaveFiles(upFile);
    }
    
    private void SaveFiles(HttpPostedFile fObj)
    {
       using(SqlConnection con = new SqlConnection(ConnectionString))// set ConnectionString
       {
           using(SqlCommand cmd = new SqlCommand(DatabaseQuery,con)) // set appropriate query
           {
              cmd.Parameters.AddWithValue("@data", ReadFile(fObj));
              con.Open();
              cmd.ExecuteNonQuery();
           }
       }
    }
    
    private byte[] ReadFile(HttpPostedFile fObj2)
    {
        byte[] data = new Byte[fObj2.ContentLength];
        fObj2.InputStream.Read(data, 0, file.ContentLength);
        return data;
    }
