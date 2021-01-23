    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      Properties.Settings.Default.Username = txtUsername.Text;
      Properties.Settings.Default.Password = txtPassword.Text;
      Properties.Settings.Default.Save();
    }
