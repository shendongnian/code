     if (checkRemember.Checked)
        {
            Properties.Settings.Default.userName = textBoxUserName.Text;
            Properties.Settings.Default.passUser = textBoxUserPass.Text;
            Properties.Settings.Default.Save();
        }[enter link description here][1]
