    class Something
    {
       public string Username;
       public string Password;
       public Dictionary<string,address> Address;
    
       public Something(string username, string password)
       {
          this.Username = username;
          this.Password = password;
          this.Address = new Dictionary<string, address>();
       }
    }
