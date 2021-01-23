    if (tbUsername.Text == "username")
    {
        if(tbPassword.Text == "password")
        {
            AdminMainMenu x = new AdminMainMenu();
            x.Show();
            t.Play();
            this.Dispose();
        }
        else
        {
            MessageBox.Show("Wrong password", "Error");
        }
    }
    else
    {
        MessageBox.Show("Wrong username", "Error");
    }
