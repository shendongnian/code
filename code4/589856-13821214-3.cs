     try
         {
         // this is creating an instance of the class created and giving the values to it.
                    
        
        var logon = new SecureLogon(
        filename, txtuser.Text, txtpassword.Text, argument);
    
        logon.Start();
          }
          catch (Exception ex)
          {
               MessageBox.Show(ex.Message,"Notification");
          }
