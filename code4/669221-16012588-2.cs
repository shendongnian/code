    private void btnSubmit_Click(object sender, EventArgs e)
        {
                Mylibrary a = new Mylibrary("localhost", "root", "", "cashieringdb");
                string user = txtLogin.Text;
                string pass = txtPassword.Text;
                string query = "SELECT * FROM register WHERE username='" + user + "' AND password=MD5('" + pass + "')";
                int result = a.Count(query);
                if (result == 1)
                {
                    LOGIN_USER = txtLogin.Text;
                    frmMain main = new frmMain();
                    main.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Login Failed! Try Again");
                    txtLogin.Text = "";
                    txtPassword.Text = "";
                }
        }
