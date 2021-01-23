    public IEnumerable<UserModel> GetAll()
    {
        using (Database db = new Database ())
        {
            List<UserModel> listOfUsers = new List<UserModel>();
            UserModel userModel = new UserModel();
            foreach(var user in db.Users)
            {
               userModel.FirstName = user.FirstName;
               userModel.LastName = user.LastName;
               listOfUsers.Add(userModel);
            }
            IEnumerable<UserModel> users = listOfUsers;
    
            return users;
        }
    }
