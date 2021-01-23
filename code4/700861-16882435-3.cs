    using (MySqlConnection con = new MySqlConnection("host=*;user=*;password=*;database=*;"))
    using (MySqlCommand cmd = con.CreateCommand())
    {
        cmd.CommandText = "SELECT username, Pain FROM members WHERE username = @UserName AND password = @Password";
        cmd.Parameters.AddWithValue("@UserName", textBox2.Text);
        cmd.Parameters.AddWithValue("@Password", textBox3.Text);
    
        con.Open();
        using (var reader = cmd.ExecuteReader())
        {
            if (reader.Read())
            {
                var username = reader.GetString(0);
    
                if (!reader.IsDBNull(1))
                {
                    var pain = reader.GetInt32(1);
                    if (pain == 1)
                    {
                        MessageBox.Show("NO");
                    }
                    else
                    {
                        MessageBox.Show("YES");
                    }
                }
            }
            else
            {
                MessageBox.Show("You Login Information is incorrect!");
            }
    
        }
    
    }
