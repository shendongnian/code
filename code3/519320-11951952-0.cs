    if(_imageUpload.HasFile)
    {
     byte[] imageData = _imageUpload.FileBytes;
    
     using(SqlConnection sqlCn = new SqlConnection("Server=localhost;database=databaseName;uid=userName;pwd=password"))
      {
        string qry = "INSERT INTO Project (thumbnail) VALUES (@thumbnail)";
        using(SqlCommand sqlCom = new SqlCommand(qry, sqlCn))
         {
           sqlCom.Parameters.Add("@thumbnail",
                                  SqlDbType.Image,
                                  imageData.Length).Value=imageData;
           sqlCn.Open();
           sqlCom.ExecuteNonQuery();
           sqlCn.Close();
         }
       }
    }
