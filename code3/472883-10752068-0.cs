    public MySqlConnection GetConnection(MySqlConnection con)
    {
            if (con.State == ConnectionState.Closed)
           {
               // local mysql database
                 con = new MySqlConnection("server=localhost;database=temp_GPS;uid=root;pwd=******");
                con.Open();
           }
              return con;
        }
