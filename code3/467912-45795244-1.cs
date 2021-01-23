                 MySqlConnection con = new MySqlConnection("SERVER=xx.xx.xx.xx;DATABASE=dbname;UID=user;PASSWORD=password;CheckParameters=False;");
                 MySqlCommand cmd = new MySqlCommand("Select * FROM login WHERE user_name = `" + username + "` AND user_pass = `" + password + "`;");
                 cmd.Connection = con;
                 con.Open();
                 MySqlDataReader reader = cmd.ExecuteReader();
                 if (reader.Read() != false)
                 {
                     if (reader.IsDBNull(0) == true)
                     {
                         cmd.Connection.Close();
                         reader.Dispose();
                         cmd.Dispose();
                         return false;
                     }
                     else
                     {
                         cmd.Connection.Close();
                         reader.Dispose();
                         cmd.Dispose();
                         return true;
                     }
                 }
                 else 
                 {
                     return false;
                 }
             }
