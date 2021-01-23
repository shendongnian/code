        public List<User> GetAllUsers()
        {
            List<User> usersList = null;
            using (var context = new AdnLineContext())
            {
                context.Configuration.ProxyCreationEnabled = false;
                usersList = context.Users.ToList();
            }
            return usersList;
        }
