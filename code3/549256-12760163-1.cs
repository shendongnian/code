    void  Form1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode.Equals(Keys.Enter))  //Invokes whenever Enter is pressed
        {
            if(!txtUserName.Focused)
            {
                 btnLogin_Click(sender, e);  //login
            }            
        }
    }
