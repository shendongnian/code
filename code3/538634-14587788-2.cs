    string conStr = "Data Source=localhost;Initial Catalog=MyDatabase;User Id=MyUser;Password=MyPassword";
    SqlConnection conn = new SqlConnection(conStr);
    conn.Open();
    conn.Close();
    Console.WriteLine(conn.ConnectionString);
