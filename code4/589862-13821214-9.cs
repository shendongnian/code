    public void verifyuser(string filename, string argument)
    {
        try
        {
            var logon = new SecureLogon(
            filename, txtuser.Text, txtpassword.Text, argument);
    
            logon.Start();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message,"Notification");
        }
    }
