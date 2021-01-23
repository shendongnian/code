    private void buttonChangePass_Click(object sender, EventArgs e)
    {
       Model_DB_Employee emp = new Model_DB_Employee();
       string username = login.returnUsername();
    
       if (textBoxNewPass.Text == string.Empty || textBoxConfirmPass.Text == string.Empty)
       {
           MessageBox.Show("Field cannot be empty!");
       }
       else
       {
           if (textBoxNewPass.Text == textBoxConfirmPass.Text)
           {
               try
               {
                   emp.changePasswd(username,textBoxConfirmPass.Text);
                   MessageBox.Show(username);
                   MessageBox.Show("Password updated!");
                   this.Hide();
                   main.Show();
               }
               catch(SystemException ex)
               {
                   MessageBox.Show("Password not updated" + ex);
               }
           }
           else
           {
               MessageBox.Show("Passwords do not match!");
           }
       }
    }
