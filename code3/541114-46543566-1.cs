    if (checkRemember.Checked)
    {
        Properties.Settings.Default.userName = textBoxUserName.Text;
        Properties.Settings.Default.passUser = textBoxUserPass.Text;
        Properties.Settings.Default.Save();
    }
    if (Properties.Settings.Default.userName != string.Empty)
    {
       textBoxUserName.Text = Properties.Settings.Default.userName;
       textBoxUserPass.Text = Properties.Settings.Default.passUser;
    }
