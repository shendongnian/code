    private void UserSettingsDemo_Load(object sender, EventArgs e)
        {
            txtServer.Text = Settings.Default.ServerNameSetting;
            txtDatabase.Text = Settings.Default.DBNameSetting;
            txtPassword.Text = Settings.Default.PasswordSetting;
            txtUserId.Text = Settings.Default.UserIdSetting;
        }
        
        private void UserSettingsDemo_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.DBNameSetting = txtDatabase.Text;
            Settings.Default.UserIdSetting = txtUserId.Text;
            Settings.Default.PasswordSetting = txtPassword.Text;
            Settings.Default.ServerNameSetting = txtServer.Text;
            Settings.Default.Save();
        }
