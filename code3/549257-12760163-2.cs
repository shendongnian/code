    void  Form1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode.Equals(Keys.Enter))  //Invokes whenever Enter is pressed
        {
            if(txtUserName.Text.Length > 0)
            {
                 if(txtPassword.Text.Length > 0)
                 {
                     btnLogin_Click(sender, e);  //login
                 }
                 else
                 {
                     //MessageBox.Show("Please Give a Password");
                     txtPassword.Focus();
                 }
            }
            else
            {
                 //MessageBox.Show("Please Give a username");
                 txtUserName.Focus();
            }
          
        }
    }
