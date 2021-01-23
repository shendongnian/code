    // omitted
    
    namespace ECBSRecruitmentAgencySoftware
    {
        public partial class LogIn : Form
        {
            // omitted
    
    
        static byte[] GenerateSaltedHash(string plainText, string salt)
        {
           HashAlgorithm algorithm = new SHA256Managed();
        
           byte[] plainTextBytes = System.Text.Encoding.Unicode.GetBytes(plainText);
           byte[] saltBytes = Convert.FromBase64String(salt);
        
           byte[] plainTextWithSaltBytes = new byte[plainTextBytes.Length + saltBytes.Length];
           salt.CopyTo(plainTextWithSaltBytes, 0);
           plainText.CopyTo(plainTextWithSaltBytes, salt.Length); 
        
           byte[] hash = algorithm.ComputeHash(plainTextWithSaltBytes);
        
           return hash;
        }
    
            public bool tryLogin(string username , string password)
            {
                 using (var con = new MySqlConnection("host=aaaaaaaa.baaadsg;user=saaaaaak;password=2333333336;database=soaaaaaaaa2;"))
                 {
                     con.Open();
    
                     var salt = string.Empty;
                     
                     using (var cmd = new MySqlCommand("Select salt From niki where user_name = @username"))
                     {
                         cmd.Parameters.AddWithValue("@username", username);
    
                         salt = cmd.ExecuteScalar() as string;
                     }
    
                     if (string.IsNullOrEmpty(salt)) return false;
    
                     var hashedPassword = GenerateSaltedHash(password, salt);
    
                     using (var cmd = new MySqlCommand("Select * FROM niki WHERE user_name = @username and user_password = @password"))
                     {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", hashedPassword);
    
                        using (var reader = cmd.ExecuteReader())
                        {
                             return reader.Read();
                        }
                     }
                 }
            }
    
            // omitted
        }
     }
