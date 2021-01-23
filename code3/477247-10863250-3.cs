    private byte[] Combine(byte[] a, byte[] b)
    {
       byte[] c = new byte[a.Length + b.Length]; 
       System.Buffer.BlockCopy(a, 0, c, 0, a.Length); 
       System.Buffer.BlockCopy(b, 0, c, a.Length, b.Length); 
       return c; 
    }
    protected void Button1_Click(object sender, EventArgs e)
    {    
        byte[] salt = new byte[16];
        RNGCryptoServiceProvider random = new RNGCryptoServiceProvider();
        random.GetNonZeroBytes(salt);
        SHA384CryptoServiceProvider sh = new SHA384CryptoServiceProvider();
        byte[] plainbytes = Encoding.ASCII.GetBytes(TextBox2.Text);
        var saltedBytes = Combine (salt, plainbytes);
        var sha = sh.ComputeHash(saltedBytes);
        SqlConnection con = new SqlConnection(constr);
        SqlCommand cmd = new SqlCommand("RegisterUser",con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlParameter param = null;
        param = cmd.Parameters.Add("@username",SqlDbType.VarChar,10);
        param.Value = TextBox1.Text;
        param = cmd.Parameters.Add("@password", SqlDbType.VarChar, 128);
        param.Value = Convert.ToBase64String(sha);
        // Store salt to use when comparing.
        param = cmd.Parameters.Add("@salt", SqlDbType.VarChar, 128);
        param.Value = Convert.ToBase64String(salt);
        try
        {
            con.Open();
            cmd.ExecuteNonQuery();
            Label4.Text = "Successfully added account!!!";
        }
        catch (Exception ex)
        {
            throw new Exception("Exception adding account"+ex.Message);
        }
        finally
        {
            con.Close();
        }
    }
    public bool searchtable() 
    {           
        SqlConnection con = new SqlConnection(constr);
        SqlCommand cmd = new SqlCommand("LogInUser",con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlParameter param = null;
        param = cmd.Parameters.Add("@username",SqlDbType.VarChar,10);
        param.Value = TextBox1.Text;
        
        try
        {
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            // Get the salt hashed password
            string dbpassmatch = reader.GetString(0);
            // Get the salt
            byte[] salt = Convert.FromBase64String(reader.GetString(1));
            // Recreate the salted hashed password
            byte[] plainbyte = Encoding.ASCII.GetBytes(TextBox2.Text);
            SHA384CryptoServiceProvider sh = new SHA384CryptoServiceProvider();
            var saltedBytes = Combine (salt, plainbytes);
            var sha = sh.ComputeHash(saltedBytes);            
            
            // Now it matches what you did in insert.
            String dbpassword = Convert.ToBase64String(sha);
            reader.Close();
            return dbpassword.Equals(dbpassmatch);
        }
        catch (Exception ex)
        {
            throw new Exception("Exception adding account" + ex.Message);
        }
        finally
        {
            con.Close();
        }
    }
