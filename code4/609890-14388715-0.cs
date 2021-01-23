    public class DAL
    {
        public static Class1 GetUser(string fname) 
        {
            var connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ToString();
            using (var conn = new SqlConnection(connectionString))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = "SELECT * FROM [tbl_user] WHERE fname = @fname";
                cmd.Parameters.AddWithValue("@fname", fname);
                using (var reader = cmd.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        return null;
                    }
    
                    var user = new Class1();
                    user.id = reader.ReadInt32(reader.GetOrdinal("id"));
                    user.fname = reader.ReadString(reader.GetOrdinal("fname"));
                    ... and so on for the other properties
                    return user;
                }
            }
        }
    }
