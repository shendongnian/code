    Public class User
    {
        public string UserName{get; set;}
        public string Password{get; set;}
        public User(string name, string pw)
        {
            this.UserName = name;
            this.Password = pw;
        }
    }
...
    User[] userArray = new User[5];
  
    for(int i=0; i<userArray.Length; i++)
    {
        userArray[i] = new User("chris", "VETS");
    }
