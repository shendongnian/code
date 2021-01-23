    protected void  btn_log_Click(object sender, EventArgs e)
    {
       using(SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=" +
                                     @"C:\Users\Sony\Documents\Library\App_Data\Library.mdf;" + 
                                     @"Integrated Security=True;User Instance=True")
        {
            con.Open();
            using(SqlCommand cmd = new SqlCommand("select count(*) from [user] where "+ 
                                       "Username=@uname and Password=@upass", con)
            {
                cmd.Parameters.AddWithValue("@uname", txt_user.Text)
                cmd.Parameters.AddWithValue("@upass", txt_pass.Text);
                int count =Convert.ToInt16(cmd.ExecuteScalar());
                ......
            }
        }
    }
