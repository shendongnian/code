    class UserController{
        public User GetUser(int userId)
        {
            return DataAccess.GetUser(userId);
        }
    }
