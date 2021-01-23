    public class Service
    {
        public User AddUser(User user) { return AddOrUpdateUser(user); }
        public User UpdateUser(User user) { return AddOrUpdateUser(user); }
        private User AddOrUpdateUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException("user", "AddOrUpdateUser: user is null");
    
            using (var context = new AdnLineContext())
            {
                context.Entry(user).State = user.UserId == 0 ?
                                            EntityState.Added :
                                            EntityState.Modified;
                context.SaveChanges();
            }
    
            return user;
        }
    }
