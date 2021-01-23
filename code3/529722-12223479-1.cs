    using System.Data.SqlClient;
    
    SqlConnection conn = new SqlConnection();
    conn.ConnectionString = 
         "Data Source=.\SQLExpress;" + 
         "User Instance=true;" + 
         "User Id=UserName;" + 
         "Password=Secret;" + 
         "AttachDbFilename=|DataDirectory|Database1.mdf;"
    conn.Open();
    
