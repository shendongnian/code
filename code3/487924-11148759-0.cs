    String ver = checkver();
    if (ver == "update")
    {
        if (RemoteFileExists(dlUrl))
        {
            Update fm = new Update();
            fm.ShowDialog();
        }
        else
            MessageBox.Show("An error occurred. Please try later.");
    }
    else if (ver == "newest")
    {
        MessageBox.Show("You are currently using the newest version.");
    }
        
