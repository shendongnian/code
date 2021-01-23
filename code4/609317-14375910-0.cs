    if (txtUserName.Text == "blah"
          && txtPassword.Text == "blah")
       {
         txtPassword.BackColor = Color.YellowGreen;
         txtUserName.BackColor = Color.YellowGreen;
         this.DialogResult = DialogResult.OK;
       }
       else
       {
         txtPassword.BackColor = Color.Salmon;
         txtUserName.BackColor = Color.Salmon;
        }
