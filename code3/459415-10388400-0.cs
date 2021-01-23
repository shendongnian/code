     public bool login(string username,string pw)
     {
    // your sql stuff
     string result = "Select * from Registration where UserName ='" +TextBoxUserName.Text + "' && password = '" + password + "';
       if (result == null)
       {
       return false;
       }
       else
        {
       return true;
        }
      }
