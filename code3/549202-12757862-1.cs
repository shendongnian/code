    protected void LoginButton_Click(object sender, EventArgs e)
            {
                if(PasswordTextBox.Text.Equals("Password"))
                {
                    MainDiv.Visible=true;
                    LoginDiv.Visible=false;
                }
            }
