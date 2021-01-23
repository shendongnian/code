            SqlDataReader dr = null;
            MySqlCommand cmd = null;
            string cmdstr = "SELECT * FROM users WHERE email='"+UsrName.Text+"' and password='"+PassWrd.Text+"' LIMIT 1";
            
            cmd = new MySqlCommand(cmdstr, connection);
            dr = cmd.ExecuteReader();
    
            if (dr.Read() == true)
            {
                MessageBox.Show("Succesvol ingelogd");
            }
            else
            {
                MessageBox.Show("Geen juiste gegevens");
            }
            connection.Close();
    
        }
