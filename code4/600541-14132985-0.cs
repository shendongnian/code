    if (File.Exists("your file path"))
     {
        // connect to database
      SqlConnection objSqlConnection=new  SqlConnection("server=127.0.0.1;uid=sa;pwd=;database=test");  
   
      objSqlConnection.Open();  
      try  
       {  
         SqlCommand sqlcom=new SqlCommand("your update sql statement here,objSqlConnection);  
         sqlcom.ExecuteNonQuery();  
       }
     catch (System.Exception ex)
       {
 	
       }
    finally
       {
         objSqlConnection.Close();
       }
    }
