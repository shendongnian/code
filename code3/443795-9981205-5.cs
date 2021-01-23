    if(user has selected an image) 
    { 
       Byte[] imageBytes = File.ReadAllBytes(imagePatient); 
       sqlCommand.Parameters.AddWithValue("Img", imageBytes); //Img is database column for images 
    } 
    else 
    { 
        sqlCommand.Parameters.Add("Img", SqlDbType.VarBinary, -1 );
        sqlCommand.Parameters["Img"].Value = DbNull.Value;
    } 
