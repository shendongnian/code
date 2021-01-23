    using System.Data.SqlClient;
    AppDomain.CurrentDomain.SetData(
    "DataDirectory", "C:\MyPath\");
     var conn = new SqlConnection();
     conn.ConnectionString = 
     "Data Source=.\SQLExpress;" + 
     "User Instance=true;" + 
     "User Id=UserName;" + 
     "Password=Secret;" + 
    "AttachDbFilename=|DataDirectory|DataBaseName.mdf;" conn.Open();  
