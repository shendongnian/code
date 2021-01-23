    protected void LoginBtn_Click(object sender, EventArgs e)
    {
        string Name = nameTextBox.Text;
        string Password = passwordTextBox.Text;
        nameTextBox.Text = "";
        passwordTextBox.Text = "";
        string connectionstring = @"Integrated Security=True;Initial Catalog=HMIS;Data Source=.\SQLEXPRESS";
        SqlConnection connection = new SqlConnection(connectionstring);
        connection.Open();
        string selectquery = "Select ID from  UsersInfo where UserName='" + @Name+ "' and Password='" + @Password + "'";
        SqlCommand cmd = new SqlCommand(selectquery, connection);
        cmd.Parameters.AddWithValue("@Name", Name);
        cmd.Parameters.AddWithValue("@Password", Password);
         //object result = cmd.ExecuteNonQuery();
        //if (result != null)
        int result = (int)cmd.ExecuteNonQuery();
        if (result > 0) 
