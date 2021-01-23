                 using (var con = new MySqlConnection("host=tara.rdb.superhosting.bg;user=sozopouk;password=27051996;database=sozopouk_test2;"))
                 {
                     con.Open();
    
                     var salt = string.Empty;
    
                     using (var cmd = new MySqlCommand("Select salt From niki where user_name = @username", con))
                     {
                         cmd.Parameters.AddWithValue("@username", username);
    
                         salt = cmd.ExecuteScalar() as string;
                     }
    
                     if (string.IsNullOrEmpty(salt)) return false;
    
                     var hashedPassword = GenerateSaltedHash(password, salt);
    
                     using (var cmd = new MySqlCommand("Select * FROM niki WHERE user_name = @username and user_password = @password", con))
                     {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", hashedPassword);
    
                        using (var reader = cmd.ExecuteReader())
                        {
                             return reader.Read();
                        }
                     }
                 }
