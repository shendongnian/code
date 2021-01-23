        private void logonButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;
            if(logon(username, password))
            {
                MessageBox.Show("Logged On Successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
            {
                MessageBox.Show(getFailureReason(), "Failure",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
