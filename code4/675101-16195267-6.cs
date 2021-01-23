     public bool CheckLogin(Window loginWindow)
     {
        var user = context.Users.Where(i => i.Username == this.Username).SingleOrDefault();
        if (user == null)
        {
            MessageBox.Show("Unable to Login, incorrect credentials.");
            return false;
        }
        else if (this.Username == user.Username || this.Password.ToString() == user.Password)
        {
            MessageBox.Show("Welcome "+ user.Username + ", you have successfully logged in.");
            this.CloseWindow(loginWindow);
            return true;
        }
        else
        {
            MessageBox.Show("Unable to Login, incorrect credentials.");
            return false;
        }
     }
     private void CloseWindow(Window window)
     {
         if (window != null)
         {
             window.Close();
         }
     }
