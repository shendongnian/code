     using System.Data.SqlClient;
     var conn = new SqlConnection();
     conn.ConnectionString = 
     "Data Source=.\SQLExpress;" + 
     "User Instance=true;" + 
     "User Id=UserName;" + 
     "Password=Secret;" + 
     "AttachDbFilename=|DataDirectory|DataBaseName.mdf;"conn.Open();
