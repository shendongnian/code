            bool foundUser = false;
            while (reader.Read())
            {
                if (tbUsername.Text == (reader["Username"].ToString()) && tbPassword.Text == (reader["Password"].ToString()))
                {
                    foundUser = true;
                    break;
                }
            }
            if (foundUser) {
                    MessageBox.Show("*Choose your best candidate. Use a Combobox.\n\n*After choosing, click Submit button to pass your vote!\n\n                           VOTE WISELY!", "How to vote?", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    UserHRForm x = new UserHRForm();
                    x.Show();
                    t.Play();
                    this.Close();
                }
                else
                {
                    SystemSounds.Hand.Play();
                    MessageBox.Show("Access Denied! Account doesn't exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);                        
                }
