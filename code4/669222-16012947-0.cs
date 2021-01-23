    private void btnSubmit_Click(object sender, EventArgs e)
    {
        bool loginSuccessful = false;
        var frmLogin = new FormLogin();
        while (frmLogin.ShowDialog() == DialogResult.OK)
        {
            // verify login details
            Mylibrary a = new Mylibrary("localhost", "root", "", "cashieringdb");
            string user = frmLogin.txtLogin.Text;
            string pass = frmLogin.txtPassword.Text;
            string query = "SELECT * FROM register WHERE username='" + user + "' AND password=MD5('" + pass + "')";
            int result = a.Count(query);
            if (result != 1)
            {
                MessageBox.Show("Login failed, try again", "Login");
            }
            else
            {
                loginSuccessful = true;
                break;
            }
        }
        if (!loginSuccessful)
        {
            // user cancelled - close main window to end application
            this.Close();
        }
    }
