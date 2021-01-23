    public List<Users> GetUserById(string _id)
    {
       MySqlConnection conn = new MySqlConnection(connstr);
       conn.Open();
       string sql = ("select * from Books where id = " + _id);
    
       MySqlCommand cmd = new MySqlCommand(sql, conn);
       MySqlDataReader reader = cmd.ExecuteReader();
      
       List<Users> users=new List<Users>();
       Users obj = new Users();
       if (reader.Read())
       {
         obj.id = Convert.ToInt32(reader[0]);
         obj.UserName = reader[1].ToString();
         users.Add(obj);
       }
       reader.Close();
       conn.Close();
       return users;
    }
