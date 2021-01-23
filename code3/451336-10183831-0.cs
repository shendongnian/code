    bool isValidUser=false;
    try
    {
     string sp_name = "dbo.CheckLoginByUserIdAndPassword2";
     using(SqlConnection SqlCon = new SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=jdwlrc_db;Data Source=."))
     {
       SqlCommand SqlCom = new SqlCommand(sp_name, SqlCon);
       SqlCom.CommandType = CommandType.StoredProcedure;
       SqlCom.Parameters.AddWithValue("@UserID", nama);
       SqlCom.Parameters.AddWithValue("@Password", password);
       SqlCon .Open();
       using(SQlDataReader objReader=SqlCom.ExecuteReader())
       {
          if(objReader.Read()
          {
             isValidUser=true;
             //You can read the values from reader if you want for future use like storing in session etc
          }
       }
       SqlCon.Close();
     }
    }
    catch(Exception ex)
    {
       //Log error 
    }
