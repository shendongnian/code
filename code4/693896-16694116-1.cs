    public class User{
       ... properties here
    }
    [WebMethod]
    public static string GetJson2()
    {
        StringBuilder sb = new StringBuilder();
        StringWriter sw = new StringWriter(sb);
        JsonWriter jsonWriter = new JsonTextWriter(sw);
        var users = new List<User>();
        try
        {
            string connstr = "server=localhost;user=root;database=cm_users;port=3306;password=root";
            MySqlConnection conn = new MySqlConnection(connstr);
            conn.Open();
            string sql = "select * from users";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int fieldcount = reader.FieldCount; // count how many columns are in the row
                object[] values = new object[fieldcount]; // storage for column values
                reader.GetValues(values); // extract the values in each column
                users.add(new User { id = reader["id"], username = reader["username"] ..});
            }
            reader.Close();
        }
        catch (MySqlException mySqlException)
        { // exception
            return mySqlException + "error";
        }
      
        return JsonConvert.SerializeObject(users);
    }
