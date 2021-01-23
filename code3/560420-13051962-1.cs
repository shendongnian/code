    private void btnEnter_Click(object sender, EventArgs e)
    {
        if (tbUsername.Text == "username")
        {
            if (tbPassword.Text == "password")
            {
                AdminMainMenu x = new AdminMainMenu();
                x.Show();
                t.Play();
                this.Dispose();
            }
            else
            {
                SystemSounds.Hand.Play();
                MessageBox.Show("Invalid Password! ", "Error");
            }    
        }
        else
        {
            SystemSounds.Hand.Play();
            MessageBox.Show("Invalid Username! ", "Error");
        }  
    }
