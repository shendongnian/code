     using System.Data.SqlClient;
     AppDomain.CurrentDomain.SetData(
     "DataDirectory", "C:\MyPath\");
     var conn = new SqlConnection();
     conn.ConnectionString = 
     "Data Source=.\SQLExpress;" + 
     "User Instance=true;" + 
     "Integrated Security=true;" + 
     "AttachDbFilename=|DataDirectory|DataBaseName.mdf;" conn.Open();
