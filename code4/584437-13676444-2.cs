       var username = txtUserName.Text;
       var password = txtPassword.Text;// there is available encryption on the web that you can use on. and your code will be like var password=enc.EncryptToString(txtPassword.Text);
       var isValidUser = from user on UserTable
                         where user.UserName == txtUserName.Text && user.Password == password && user.Status == 1
                         select user;  
       if(isValiduser.Count() > 0)
       {
         //OK you can log on
       }
       else
       {
         //user credential is invalid
       }       
