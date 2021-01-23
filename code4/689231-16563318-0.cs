    using(MySqlConnection con = new MySqlConnection("your_connection_string_here"))
    {
            con.Open();
            string query = "SELECT COUNT(*) FROM tblOrder WHERE dateTime_coded=@dateTimeNow";
            using(MySqlCommand cmd = new MySqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@dateTimeNow", 
                         Convert.ToDateTime(DateTime.Now).ToString("yyyy-MM"));
                int count = (int)cmd.ExecuteScalar();
                Console.WriteLine("There are " + count.ToString() + " records");
            }
    }
