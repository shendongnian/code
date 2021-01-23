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
        if(tbPassword.Text == "password")
        {
            MessageBox.Show("Wrong username", "Error");
        }
        else
        {
            MessageBox.Show("Wrong username and password", "Error");
        }
    }
