    private void button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        try
        {
            con.ConnectionString = "Server = blabla; Database = MoinMoun; User Id = Aema; password = 12345";
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT username,password FROM Admin WHERE username=@userName and password=@passWord", con);
            cmd.Parameters.Add(new SqlParameter("@userName", txtusername.Text));
            cmd.Parameters.Add(new SqlParameter("@passWord", txtpassword.Text));
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                con.Close();
                dr.Close();
                Form2 frm = new Form2();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid User! Try again with VALID username and password");
            }
            if (!dr.IsClosed)
                dr.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally
        {
            if (con.State == System.Data.ConnectionState.Open)
                con.Close();
            con.Dispose();
        }
    }
