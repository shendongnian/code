     using System.Data.SqlClient;
     var conn = new SqlConnection();
     conn.ConnectionString = 
     "Data Source=.\SQLExpress;" + 
     "User Instance=true;" + 
     "Integrated Security=true;" + 
     "AttachDbFilename=|DataDirectory|DataBaseName.mdf;" conn.Open();
