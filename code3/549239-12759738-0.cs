    void  Form1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode.Equals(Keys.Enter))  //Invokes whenever Enter is pressed
        {
            if (txtPassword.ContainsFocus)
            {
                btnLogin_Click(sender, e);  //login
            }
            else
            {
                this.txtPassword.Focus();
            }
        }
    }
    private void btnLogin_Click(object sender, EventArgs e)
    {
        if (txtUserName.Text.Equals("Administrator") && txtPassword.Text.Equals("123"))
        {
            MessageBox.Show("Test");
        }
        else if (txtUserName.Text.Equals("Clerk") && txtPassword.Text.Equals("123"))
        {
            //function to access clerk features
        }
        else
        {
            MessageBox.Show("Please Enter correct details", "Login Error");
        }
    }
