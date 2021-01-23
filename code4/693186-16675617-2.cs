    using (MySqlConnection conn = openconnection.GetConn())
    {
        using (MySqlCommand cmd = new MySqlCommand("INSERT INTO table_name (name,lastname,address) VALUES (@name,@lastname,@address);", conn);
        {
            cmd.Parameters.AddWithValue("@name", name_textbox.Text.NullString());
            cmd.Parameters.AddWithValue("@lastname", lastname_textbox.Text.NullString());
            cmd.Parameters.AddWithValue("@address", address_textbox.Text.NullString());
            
            cmd.ExecuteNonQuery();
        }
    }
    namespace System
    {
        public static class StringExtensions
        {
            public static string NullString(this string s)
            {
                return string.IsNullOrEmpty(s) ? DBNull.Value : (object)s;
            }
        }
    }
