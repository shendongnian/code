    SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE Username='" + userText.toString() + "' and Password='" + passText.toString() + "'", cn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show(username + " / " + usertext);
                MessageBox.Show(password + " / " + passtext);
                this.Hide();
                Dashboard dashboard = new Dashboard();
                dashboard.ShowDialog();
                this.Close();
            }
            else
            {
                    MessageBox.Show("Invalid Username or Password");
            }
