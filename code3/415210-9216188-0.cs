    SqlConnection Conn = new SqlConnection(YourConnectionString);
    SqlCommand YourSqlCommand = new SqlCommand();
    YourSqlCommand.Connection = Conn;
    YourSqlCommand.CommandText = "select * from yourtable";
    
    DataTable dt = new DataTable();
    
    SqlDataAdapter sda = new SqlDataAdapter(YourSqlCommand);
    
    sda.Fill(dt);
