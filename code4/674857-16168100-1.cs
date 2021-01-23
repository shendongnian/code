    string connString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
    MySqlConnection conn = new MySqlConnection(connString);
    conn.Open();
    MySqlCommand comm = conn.CreateCommand();
    comm.CommandText = "INSERT INTO room(person,address) VALUES(?person, ?address)";
    comm.Parameters.Add("?person", "Myname");
    comm.Parameters.Add("?address", "Myaddress");
    comm.ExecuteNonQuery();
    conn.Close();
