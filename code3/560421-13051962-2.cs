    private void btnEnter_Click(object sender, EventArgs e)
    {
        if (tbUsername.Text != "username")
        {
            SystemSounds.Hand.Play();
            MessageBox.Show("Invalid Username! ", "Error");
            return;
        }
    
        if (tbPassword.Text != "password")
        {
            SystemSounds.Hand.Play();
            MessageBox.Show("Invalid Password! ", "Error");
            return;
        } 
    
        //If we got here in code execution, then both username and password are correct
        AdminMainMenu x = new AdminMainMenu();
        x.Show();
        t.Play();
        this.Dispose();
    }
