    void  Form1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode.Equals(Keys.Enter))  //Invokes whenever Enter is pressed
        {
            btnLogin_Click(sender, e);  //login
        }
    }
