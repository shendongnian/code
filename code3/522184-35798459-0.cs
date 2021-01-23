    List<Users> list_users = new List<Users>();
    MySqlConnection cn = new MySqlConnection("connection");
    MySqlCommand cm = new MySqlCommand("select * from users",cn);
    try
    {
        cn.Open();
        MySqlDataReader dr = cm.ExecuteReader();
        while (dr.Read())
        {
            list_users.Add(new Users(dr));
        }
    }
    catch { /* error */ }
    finally { cn.Close(); }
