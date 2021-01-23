    private void loginButton_Click(object sender, EventArgs e)
    {
        if (Authenticated(username.Text, password.Text))
        {
            var mainForm = new MainForm();
            this.Visible = false;
            mainForm.Show(this);
        }
    }
