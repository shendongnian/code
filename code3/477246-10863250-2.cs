    protected void Button1_Click(object sender, EventArgs e)
    {
    
        SHA384CryptoServiceProvider sh = new SHA384CryptoServiceProvider();
        byte[] plainbytes = Encoding.ASCII.GetBytes(TextBox2.Text);
        var sha = sh.ComputeHash(plainbytes);
        SqlConnection con = new SqlConnection(constr);
        SqlCommand cmd = new SqlCommand("RegisterUser",con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlParameter param = null;
        param = cmd.Parameters.Add("@username",SqlDbType.VarChar,10);
        // Increase column size and parameters.
        param.Value = TextBox1.Text;
        param = cmd.Parameters.Add("@password", SqlDbType.VarChar, 128);
        param.Value = Convert.ToBase64String(sha);
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
        SHA384CryptoServiceProvider sha384 = new SHA384CryptoServiceProvider();
        byte[] plainbyte = Encoding.ASCII.GetBytes(TextBox2.Text);
        var sha2 = sha384.ComputeHash(plainbyte);
    
        bool passmatch=false;
        SqlConnection con = new SqlConnection(constr);
        SqlCommand cmd = new SqlCommand("LogInUser",con);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlParameter param = null;
        param = cmd.Parameters.Add("@username",SqlDbType.VarChar,10);
        param.Value = TextBox1.Text;
        // Now it matches what you did in insert.
        String dbpassword = Convert.ToBase64String(sha2);
        try
        {
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            // Make sure you are actually returning the hash
            string dbpassmatch = reader.GetString(0);
            reader.Close();
            passmatch = dbpassword.Equals(dbpassmatch);
            return passmatch;
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
