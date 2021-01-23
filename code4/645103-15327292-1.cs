    private void button1_Click(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(conn_str);
        conn.Open();
        string sql = "SELECT User, Password 
            FROM UsersData WHERE User=@user and Password=@password"
        SqlCommand mycommand = new SqlCommand(sql, conn);
        //parameterize your query!
        mycommand.Parameters.AddWithValue("user", txtuser.text);
        mycommand.Parameters.AddWithValuye("password", txtpassword.password);
        SqlDataReader reader = mycommand.ExecuteReader();
        if(reader == null)
        {
            label3.Text = "Database query failed!";
        }
        else if(reader.HasRows)
        {
            Form1 formload = new Form1();
            formload.Show();
        }
        else
        {
            label3.Text = "Invalid Username or Password !";
        }
