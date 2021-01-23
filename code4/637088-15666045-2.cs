    public class CustomSimpleMembershipProvider
    {
        private readonly OAuthNoMigrateContext _db = new OAuthNoMigrateContext();
        public bool CreateUser(string username, string password, User user)
        {
            var userCreated = false;
            WebSecurity.CreateUserAndAccount(username, password);
            var userProfile = _db.UserProfiles.FirstOrDefault(u => u.UserName == username);
            // Check if user exists
            if (userProfile != null)
            {
                user.UserProfile = userProfile;
                try
                {
                    _db.Users.Add(user);
                    _db.SaveChanges();
                    userCreated = true;
                }
                catch (Exception)
                {
                    //Add logging or throw whatever exceptions needed
                    throw;
                }
            }
            return userCreated;
        }
    }
