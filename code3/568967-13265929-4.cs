    public bool Login(string username, string password)
    {
       User[] userList = GetAllUsers();
       for (int i = 0; i < rows.Count; ++i)
            {
                if (user[i].GetUsername() == username && user[i].GetPassword == password)
                {
                  return true;                
                }
            }
            return false;
    }
    
