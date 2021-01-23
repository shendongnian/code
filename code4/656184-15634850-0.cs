    private void UserNameInput_Leave(object sender, EventArgs e)
        {
            if (sender.GetType() != typeof(TextBox))
            {
                return;
            }
            TextBox tBox = (TextBox)sender;
            //pop up a warning when user name input is invalid
            if (!UserNameRE.IsMatch(UserNameInput.Text) && tBox.Name == UserNameInput.Name)
            {
                MessageBox.Show("Invalid User Name!");
                this.UserNameInput.Text = "";
                this.UserNameInput.Focus();
            }
        }
