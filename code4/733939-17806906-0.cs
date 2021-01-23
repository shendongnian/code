	CREATE TABLE [dbo].[Employee](
		 [emp_id] [int] NOT NULL,
		 [emp_name] [varchar](50) NOT NULL,
		 [emp_image] [image] NULL
	 ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
	 
 
	string fileName = @"D:\MyImage.jpg";
    string connectionString = "Password=PWD;Persist Security " + 
        "Info=True;User ID=USER;Initial Catalog=DATABASE;Data Source=SQLSERVER";
	using (SqlConnection sqlConnection = new SqlConnection(connectionString))
    {
     
        FileInfo finfo = new FileInfo(fileName);
     
        byte[] btImage = new byte[finfo.Length];
        FileStream fStream = finfo.OpenRead();
    
       fStream.Read(btImage, 0, btImage.Length);
      fStream.Close();
    
   
       using (SqlCommand sqlCommand = new SqlCommand(
            "INSERT INTO Employee (emp_id, emp_name, " + 
            "emp_image) VALUES(@emp_id, @emp_name, @emp_image)", 
            sqlConnection))
       {
    
           sqlCommand.Parameters.AddWithValue("@emp_id", 2);
           sqlCommand.Parameters.AddWithValue("@emp_name", "Employee Name");
           SqlParameter imageParameter = 
                 new SqlParameter("@emp_image", SqlDbType.Image);
           imageParameter.Value = btImage;
    
           sqlCommand.Parameters.Add(imageParameter);
  
           sqlConnection.Open();
           sqlCommand.ExecuteNonQuery();
           sqlConnection.Close();
       }
  
	}
