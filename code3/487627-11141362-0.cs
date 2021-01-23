    private void loginButton_Click(object sender, EventArgs e)
    {
        if (isValidCredentials())
          DialogResult = DialogResult.OK;
        else
        {
          MessageBox.Show("Failed to login or some other error");
          DialogResult = DialogResult.None;
        }
    }
