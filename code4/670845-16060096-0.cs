    if (user == null)
     {
         MessageBox.Show("Unable to Login, incorrect credentials.");
     }
     else if (this.Username == user.Username && this.Password == user.Password)
     {
         MessageBox.Show("Successfully Logged in, " + user.Username + "");
     }
     else
     {
         MessageBox.Show("Unable to Login, incorrect credentials.");
     }
