    using System.Data.SqlClient;
    
    SqlConnection conn = new SqlConnection();
    conn.ConnectionString = 
         "Data Source=.\SQLExpress;" + 
         "User Instance=true;" + 
         "User Id=UserName;" + 
         "Password=Secret;" + 
         "AttachDbFilename=|DataDirectory|Database1.mdf;"
    conn.Open();
    
    if you use a windows authentication use
    using System.Data.SqlClient;
    SqlConnection conn = new SqlConnection();
    conn.ConnectionString = 
         "Data Source=.\SQLExpress;" + 
         "User Instance=true;" + 
         "Integrated Security=true;" + 
         "AttachDbFilename=|DataDirectory|Database1.mdf;"
    conn.Open();
