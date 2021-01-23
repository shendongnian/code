      using (MySqlConnection con = new MySqlConnection("server=localhost;database=Data_GPS;uid=root;pwd=******")
      {
            con.Open();
            using (MySqlCommand  cmd = new MySqlCommand("insert into Data values (null, @Parname , @Parname2, @Parname3);", con)
            {
                // change MySqlDbType.Double to reflect the real data type in the table.
                cmd.Parameters.Add("@Parname", MySqlDbType.Double).Value = deciLat;
                cmd.Parameters.Add("@Parname2", MySqlDbType.Double).Value = deciLon;
                cmd.Parameters.Add("@Parname3", MySqlDbType.DateTime).Value = time;
                cmd.ExecuteNonQuery();
            }
      }
