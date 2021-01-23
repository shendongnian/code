    class Login
    {
      public Login()
      {
    
      }
    
      public bool CheckLogin(string userName, string password)
      {
       // Do your validation here. 
       If every thing goes fine 
         return True.
       else
         throw Exception("custom message.");
      }
    
    }
    
    class Input  //class which takes input.
    {
      Login login = new Login();
    
      public void TakeInput(string username, string password)
      { 
         try
         {
            login.CheckLogin(username, password);
         }
         catch(Exception ex)
         { 
           MessageBox.show(ex.message);
         } 
      }  
    
    }
