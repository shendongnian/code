    // if exists, show a message error
    if (exists)
    {
        MessageBox.Show("Username: " + txtUsername.Text + "  already Exists");
               //errorPassword.SetError(txtUsername, "This username has been using by another user.");
    }
    else
    {
        // does not exists, so, persist the user
        using (SqlCommand cmd = new SqlCommand("INSERT INTO [User] values (@Forename, @Surname, @Username, @Password)", con))
        {
             cmd.Parameters.AddWithValue("@Forename", txtForename.Text);
             cmd.Parameters.AddWithValue("@Surname", txtSurname.Text);
             cmd.Parameters.AddWithValue("@UserName", txtUsername.Text);
             cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
             cmd.ExecuteNonQuery();
        }
        MessageBox.Show("Sucessfully Signed Up");
        Form1 signin = new Form1();
        signin.Show();
        this.Close();
    }
    con.Close();
